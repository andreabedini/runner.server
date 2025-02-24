﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using GitHub.DistributedTask.WebApi;
using GitHub.Services.Location;
using GitHub.Services.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Runner.Server.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Runner.Server.Controllers
{
    [ApiController]
    [Route("_apis/v1/[controller]")]
    [Route("{owner}/{repo}/_apis/v1/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "Agent")]
    public class AgentSessionController : VssControllerBase
    {

        private IMemoryCache _cache;

        private SqLiteDb _context;
    

        public AgentSessionController(IMemoryCache cache, SqLiteDb context, IConfiguration conf) : base(conf)
        {
            _cache = cache;
            _context = context;
        }

        [HttpPost("{poolId}")]
        [SwaggerResponse(200, type: typeof(TaskAgentSession))]
        public async Task<IActionResult> Create(int poolId, [FromBody, Vss] TaskAgentSession session)
        {
            session.SessionId = Guid.NewGuid();
            var aes = Aes.Create();
            Agent agent = Agent.GetAgent(_cache, _context, poolId, session.Agent.Id);
            if(agent == null) {
                return NotFound();
            }
            Session _session = _cache.Set(session.SessionId, new Session() {
                TaskAgentSession = session,
                Agent = agent,
                Key = aes
                
            });
            // session.EncryptionKey = new TaskAgentSessionKey() {
            //     Encrypted = false,
            //     Value = aes.Key
            // };
            if(agent.Capabilities?.Count > 0) {
                session.EncryptionKey = new TaskAgentSessionKey() {
                    Encrypted = true,
                    Value = _session.Agent.PublicKey.Encrypt(aes.Key, RSAEncryptionPadding.OaepSHA1)
                };
            } else {
                session.UseFipsEncryption = true;
                session.EncryptionKey = new TaskAgentSessionKey() {
                    Encrypted = true,
                    Value = _session.Agent.PublicKey.Encrypt(aes.Key, RSAEncryptionPadding.OaepSHA256)
                };
            }

            _session.Timer = new System.Timers.Timer();
            _session.Timer.AutoReset = false;
            _session.Timer.Interval = 60000;
            _session.Timer.Elapsed += async (a,b) => {
                MessageController.sessions.TryRemove(_session, out _);
                _cache.Remove(session.SessionId);
                try {
                    await _session.MessageLock.WaitAsync(50000);
                    _session.DropMessage?.Invoke("Session deleted by Timeout");
                    _session.DropMessage = null;
                    _session.MessageLock.Dispose();
                } catch {
                    
                }
            };
            _session.Timer.Start();

            MessageController.sessions.TryAdd(_session, _session);
            
            return await Ok(session);
        }

        [HttpDelete("{poolId}/{sessionId}")]
        public async Task Delete(int poolId, Guid sessionId)
        {
            Session session;
            if(_cache.TryGetValue(sessionId, out session)) {
                MessageController.sessions.TryRemove(session, out _);
                _cache.Remove(sessionId);
                try {
                    await session.MessageLock.WaitAsync(50000);
                    session.DropMessage?.Invoke("Session deleted by Agent");
                    session.DropMessage = null;
                    session.MessageLock.Dispose();
                } catch {

                }
            }
        }
    }
}
