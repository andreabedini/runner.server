﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using GitHub.DistributedTask.WebApi;
using GitHub.Runner.Sdk;
using GitHub.Services.Location;
using GitHub.Services.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Runner.Server.Controllers
{
    [ApiController]
    [Route("_apis/v1/tasks")]
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "AgentJob")]
    public class TaskController : VssControllerBase
    {
        private string GitServerUrl;
        private IMemoryCache cache;

        private string GitHubAppPrivateKeyFile { get; }
        private int GitHubAppId { get; }
        private bool AllowPrivateActionAccess { get; }
        private string GITHUB_TOKEN;
        private string GitApiServerUrl;
        private List<ActionDownloadUrls> downloadUrls;
        private class ActionDownloadUrls
        {
            public string TarbalUrl { get => TarballUrl; set => TarballUrl = value; }
            public string ZipbalUrl { get => ZipballUrl; set => ZipballUrl = value; }
            public string TarballUrl { get; set; }
            public string ZipballUrl { get; set; }
            public string GitApiServerUrl { get; set; }
            public string GITHUB_TOKEN { get; set; }
        }

        public TaskController(IConfiguration configuration, IMemoryCache cache) : base(configuration)
        {
            downloadUrls = configuration.GetSection("Runner.Server:ActionDownloadUrls").Get<List<ActionDownloadUrls>>();
            GitHubAppPrivateKeyFile = configuration.GetSection("Runner.Server")?.GetValue<string>("GitHubAppPrivateKeyFile") ?? "";
            GitHubAppId = configuration.GetSection("Runner.Server")?.GetValue<int>("GitHubAppId") ?? 0;
            AllowPrivateActionAccess = configuration.GetSection("Runner.Server").GetValue<bool>("AllowPrivateActionAccess");
            GITHUB_TOKEN = configuration.GetSection("Runner.Server")?.GetValue<String>("GITHUB_TOKEN") ?? "";
            GitApiServerUrl = configuration.GetSection("Runner.Server")?.GetValue<String>("GitApiServerUrl") ?? "";
            GitServerUrl = configuration.GetSection("Runner.Server")?.GetValue<String>("GitServerUrl") ?? "";
            this.cache = cache;
        }

        [HttpPatch]
        [HttpPost]
        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> GetTask() {
            var body = await new StreamReader(Request.Body).ReadToEndAsync();
            return Ok();
        }

        [HttpGet("{taskid}")]
        [AllowAnonymous]
        public IActionResult GetTask(Guid taskid) {
            return Ok();
        }

        [HttpGet("{taskid}/{version}")]
        [AllowAnonymous]
        public IActionResult GetTaskArchive(Guid taskid, string version) {
            var srunid = User.FindFirst("runid")?.Value;
            var tasksByNameAndVersion = srunid != null && long.TryParse(srunid, out var runid) && MessageController.WorkflowStates.TryGetValue(runid, out var state) && state.TasksByNameAndVersion != null ? state.TasksByNameAndVersion : cache.GetOrCreate("tasksByNameAndVersion", ce => {
                var ( tasks, tasksByNameAndVersion ) = TaskMetaData.LoadTasks(Path.Combine(GharunUtil.GetLocalStorage(), "AzureTasks"));
                return tasksByNameAndVersion;
            });
            var callback = tasksByNameAndVersion[$"{taskid}@{version}"].ArchiveCallback;
            if(callback != null) {
                return callback(ControllerContext);
            }
            return new FileStreamResult(System.IO.File.OpenRead(tasksByNameAndVersion[$"{taskid}@{version}"].ArchivePath), "application/zip") { EnableRangeProcessing = true };
        }
    }
}
