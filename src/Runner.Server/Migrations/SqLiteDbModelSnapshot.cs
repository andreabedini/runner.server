﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Runner.Server.Models;

namespace Runner.Server.Migrations
{
    [DbContext(typeof(SqLiteDb))]
    partial class SqLiteDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("GitHub.DistributedTask.WebApi.AgentLabel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TaskAgentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TaskAgentId");

                    b.ToTable("AgentLabel");
                });

            modelBuilder.Entity("GitHub.DistributedTask.WebApi.TaskAgentPool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AgentCloudId")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("AutoProvision")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("AutoSize")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsHosted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsInternal")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsLegacy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PoolType")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Scope")
                        .HasColumnType("TEXT");

                    b.Property<int>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TargetSize")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TaskAgentPool");
                });

            modelBuilder.Entity("GitHub.DistributedTask.WebApi.TaskAgentReference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccessPoint")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Ephemeral")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("OSDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProvisioningState")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Version")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TaskAgentReference");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TaskAgentReference");
                });

            modelBuilder.Entity("GitHub.DistributedTask.WebApi.TaskLogReference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TaskLogReference");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TaskLogReference");
                });

            modelBuilder.Entity("GitHub.DistributedTask.WebApi.TimelineRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AgentPlatform")
                        .HasColumnType("TEXT");

                    b.Property<int>("Attempt")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChangeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CurrentOperation")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DetailsId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ErrorCount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("FinishTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Identifier")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("JobId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LogId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("NoticeCount")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PercentComplete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RecordType")
                        .HasColumnType("TEXT");

                    b.Property<string>("RefName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Result")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ResultCode")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("State")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("TimelineId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WarningCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WorkerName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DetailsId");

                    b.HasIndex("JobId");

                    b.HasIndex("LogId");

                    b.ToTable("TimeLineRecords");
                });

            modelBuilder.Entity("GitHub.DistributedTask.WebApi.TimelineReference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ChangeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TimelineReference");
                });

            modelBuilder.Entity("OwnerPool", b =>
                {
                    b.Property<long>("OwnersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PoolsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OwnersId", "PoolsId");

                    b.HasIndex("PoolsId");

                    b.ToTable("OwnerPool");
                });

            modelBuilder.Entity("Runner.Server.Models.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Exponent")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("Modulus")
                        .HasColumnType("BLOB");

                    b.Property<int?>("PoolId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TaskAgentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PoolId");

                    b.HasIndex("TaskAgentId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("Runner.Server.Models.ArtifactContainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AttemptId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AttemptId");

                    b.ToTable("Artifacts");
                });

            modelBuilder.Entity("Runner.Server.Models.ArtifactFileContainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContainerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<long?>("Size")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId");

                    b.ToTable("ArtifactFileContainer");
                });

            modelBuilder.Entity("Runner.Server.Models.ArtifactRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FileContainerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("GZip")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StoreName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FileContainerId");

                    b.ToTable("ArtifactRecords");
                });

            modelBuilder.Entity("Runner.Server.Models.CacheRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ref")
                        .HasColumnType("TEXT");

                    b.Property<string>("Repo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Storage")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Caches");
                });

            modelBuilder.Entity("Runner.Server.Models.Job", b =>
                {
                    b.Property<Guid>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("CancelTimeoutMinutes")
                        .HasColumnType("REAL");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ContinueOnError")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Matrix")
                        .HasColumnType("TEXT");

                    b.Property<long>("RequestId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Result")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TimeLineId")
                        .HasColumnType("TEXT");

                    b.Property<double>("TimeoutMinutes")
                        .HasColumnType("REAL");

                    b.Property<string>("WorkflowIdentifier")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WorkflowRunAttemptId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<string>("repo")
                        .HasColumnType("TEXT");

                    b.Property<long>("runid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("workflowname")
                        .HasColumnType("TEXT");

                    b.HasKey("JobId");

                    b.HasIndex("WorkflowRunAttemptId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Runner.Server.Models.JobOutput", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("JobId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("JobOutput");
                });

            modelBuilder.Entity("Runner.Server.Models.Owner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PrivateKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("PublicKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.Property<string>("Token")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("Runner.Server.Models.Pool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("RepositoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TaskAgentPoolId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RepositoryId");

                    b.HasIndex("TaskAgentPoolId");

                    b.ToTable("Pools");
                });

            modelBuilder.Entity("Runner.Server.Models.Repository", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<long?>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PrivateKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("PublicKey")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Repository");
                });

            modelBuilder.Entity("Runner.Server.Models.SqLiteDb+LogStorage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RefId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RefId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Runner.Server.Models.Workflow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT");

                    b.Property<long?>("RepositoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Workflows");
                });

            modelBuilder.Entity("Runner.Server.Models.WorkflowRun", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WorkflowId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowId");

                    b.ToTable("WorkflowRun");
                });

            modelBuilder.Entity("Runner.Server.Models.WorkflowRunAttempt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attempt")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventName")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventPayload")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ref")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Result")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sha")
                        .HasColumnType("TEXT");

                    b.Property<string>("StatusCheckSha")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TimeLineId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Workflow")
                        .HasColumnType("TEXT");

                    b.Property<long?>("WorkflowRunId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowRunId");

                    b.ToTable("WorkflowRunAttempt");
                });

            modelBuilder.Entity("GitHub.DistributedTask.WebApi.TaskAgent", b =>
                {
                    b.HasBaseType("GitHub.DistributedTask.WebApi.TaskAgentReference");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MaxParallelism")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("StatusChangedOn")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("TaskAgent");
                });

            modelBuilder.Entity("GitHub.DistributedTask.WebApi.TaskLog", b =>
                {
                    b.HasBaseType("GitHub.DistributedTask.WebApi.TaskLogReference");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("IndexLocation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastChangedOn")
                        .HasColumnType("TEXT");

                    b.Property<long>("LineCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("TaskLog");
                });

            modelBuilder.Entity("GitHub.DistributedTask.WebApi.AgentLabel", b =>
                {
                    b.HasOne("GitHub.DistributedTask.WebApi.TaskAgent", null)
                        .WithMany("Labels")
                        .HasForeignKey("TaskAgentId");
                });

            modelBuilder.Entity("GitHub.DistributedTask.WebApi.TimelineRecord", b =>
                {
                    b.HasOne("GitHub.DistributedTask.WebApi.TimelineReference", "Details")
                        .WithMany()
                        .HasForeignKey("DetailsId");

                    b.HasOne("Runner.Server.Models.Job", null)
                        .WithMany("TimeLine")
                        .HasForeignKey("JobId");

                    b.HasOne("GitHub.DistributedTask.WebApi.TaskLogReference", "Log")
                        .WithMany()
                        .HasForeignKey("LogId");

                    b.Navigation("Details");

                    b.Navigation("Log");
                });

            modelBuilder.Entity("OwnerPool", b =>
                {
                    b.HasOne("Runner.Server.Models.Owner", null)
                        .WithMany()
                        .HasForeignKey("OwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Runner.Server.Models.Pool", null)
                        .WithMany()
                        .HasForeignKey("PoolsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Runner.Server.Models.Agent", b =>
                {
                    b.HasOne("Runner.Server.Models.Pool", "Pool")
                        .WithMany("Agents")
                        .HasForeignKey("PoolId");

                    b.HasOne("GitHub.DistributedTask.WebApi.TaskAgent", "TaskAgent")
                        .WithMany()
                        .HasForeignKey("TaskAgentId");

                    b.Navigation("Pool");

                    b.Navigation("TaskAgent");
                });

            modelBuilder.Entity("Runner.Server.Models.ArtifactContainer", b =>
                {
                    b.HasOne("Runner.Server.Models.WorkflowRunAttempt", "Attempt")
                        .WithMany("Artifacts")
                        .HasForeignKey("AttemptId");

                    b.Navigation("Attempt");
                });

            modelBuilder.Entity("Runner.Server.Models.ArtifactFileContainer", b =>
                {
                    b.HasOne("Runner.Server.Models.ArtifactContainer", "Container")
                        .WithMany("FileContainer")
                        .HasForeignKey("ContainerId");

                    b.Navigation("Container");
                });

            modelBuilder.Entity("Runner.Server.Models.ArtifactRecord", b =>
                {
                    b.HasOne("Runner.Server.Models.ArtifactFileContainer", "FileContainer")
                        .WithMany("Files")
                        .HasForeignKey("FileContainerId");

                    b.Navigation("FileContainer");
                });

            modelBuilder.Entity("Runner.Server.Models.Job", b =>
                {
                    b.HasOne("Runner.Server.Models.WorkflowRunAttempt", "WorkflowRunAttempt")
                        .WithMany("Jobs")
                        .HasForeignKey("WorkflowRunAttemptId");

                    b.Navigation("WorkflowRunAttempt");
                });

            modelBuilder.Entity("Runner.Server.Models.JobOutput", b =>
                {
                    b.HasOne("Runner.Server.Models.Job", "Job")
                        .WithMany("Outputs")
                        .HasForeignKey("JobId");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Runner.Server.Models.Pool", b =>
                {
                    b.HasOne("Runner.Server.Models.Repository", null)
                        .WithMany("Pools")
                        .HasForeignKey("RepositoryId");

                    b.HasOne("GitHub.DistributedTask.WebApi.TaskAgentPool", "TaskAgentPool")
                        .WithMany()
                        .HasForeignKey("TaskAgentPoolId");

                    b.Navigation("TaskAgentPool");
                });

            modelBuilder.Entity("Runner.Server.Models.Repository", b =>
                {
                    b.HasOne("Runner.Server.Models.Owner", "Owner")
                        .WithMany("Repositories")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Runner.Server.Models.SqLiteDb+LogStorage", b =>
                {
                    b.HasOne("GitHub.DistributedTask.WebApi.TaskLog", "Ref")
                        .WithMany()
                        .HasForeignKey("RefId");

                    b.Navigation("Ref");
                });

            modelBuilder.Entity("Runner.Server.Models.Workflow", b =>
                {
                    b.HasOne("Runner.Server.Models.Repository", "Repository")
                        .WithMany("Workflows")
                        .HasForeignKey("RepositoryId");

                    b.Navigation("Repository");
                });

            modelBuilder.Entity("Runner.Server.Models.WorkflowRun", b =>
                {
                    b.HasOne("Runner.Server.Models.Workflow", "Workflow")
                        .WithMany("Runs")
                        .HasForeignKey("WorkflowId");

                    b.Navigation("Workflow");
                });

            modelBuilder.Entity("Runner.Server.Models.WorkflowRunAttempt", b =>
                {
                    b.HasOne("Runner.Server.Models.WorkflowRun", "WorkflowRun")
                        .WithMany("Attempts")
                        .HasForeignKey("WorkflowRunId");

                    b.Navigation("WorkflowRun");
                });

            modelBuilder.Entity("Runner.Server.Models.ArtifactContainer", b =>
                {
                    b.Navigation("FileContainer");
                });

            modelBuilder.Entity("Runner.Server.Models.ArtifactFileContainer", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("Runner.Server.Models.Job", b =>
                {
                    b.Navigation("Outputs");

                    b.Navigation("TimeLine");
                });

            modelBuilder.Entity("Runner.Server.Models.Owner", b =>
                {
                    b.Navigation("Repositories");
                });

            modelBuilder.Entity("Runner.Server.Models.Pool", b =>
                {
                    b.Navigation("Agents");
                });

            modelBuilder.Entity("Runner.Server.Models.Repository", b =>
                {
                    b.Navigation("Pools");

                    b.Navigation("Workflows");
                });

            modelBuilder.Entity("Runner.Server.Models.Workflow", b =>
                {
                    b.Navigation("Runs");
                });

            modelBuilder.Entity("Runner.Server.Models.WorkflowRun", b =>
                {
                    b.Navigation("Attempts");
                });

            modelBuilder.Entity("Runner.Server.Models.WorkflowRunAttempt", b =>
                {
                    b.Navigation("Artifacts");

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("GitHub.DistributedTask.WebApi.TaskAgent", b =>
                {
                    b.Navigation("Labels");
                });
#pragma warning restore 612, 618
        }
    }
}
