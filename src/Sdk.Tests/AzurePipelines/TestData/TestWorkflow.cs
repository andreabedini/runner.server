using Xunit.Abstractions;

namespace Runner.Server.Azure.Devops
{
    public class TestWorkflow : IXunitSerializable
    {
        /// <summary>
        /// Serialization Constructor
        /// </summary>
#pragma warning disable CS8618
        public TestWorkflow() { }
#pragma warning restore CS8618

        public TestWorkflow(string workingDirectory, string file)
        {
            WorkingDirectory = workingDirectory;
            File = file.Replace(@"\", "/");
            LocalRepository = Array.Empty<string>();
        }

        /// <summary>
        /// Base Working Directory for Test
        /// </summary>
        public string WorkingDirectory { get; private set; }

        /// <summary>
        /// Path to Pipeline
        /// </summary>
        public string File { get; private set; }

        #region meta-data
        /// <summary>
        /// Display Name for Test
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Additional repository information needed for workflow
        /// </summary>
        public string[] LocalRepository { get; set; }

        /// <summary>
        /// Expected Exception for YAML Parsing scenario
        /// </summary>
        public Type? ExpectedException { get; set; }

        /// <summary>
        /// Expected Exception Message for YAML Parsing scenario
        /// </summary>
        public string? ExpectedErrorMessage { get; set; } 
        #endregion

        #region IXUnitSerializable

        /// <summary>
        /// Hydrate Test data from xUnit Test discovery
        /// </summary>
        public void Deserialize(IXunitSerializationInfo info)
        {
            Name = info.GetValue<string>(nameof(Name));
            WorkingDirectory = info.GetValue<string>(nameof(WorkingDirectory));
            File = info.GetValue<string>(nameof(File));
            LocalRepository = info.GetValue<string?>(nameof(LocalRepository))?.Split(";") ?? Array.Empty<string>();
            ExpectedErrorMessage = info.GetValue<string?>(nameof(ExpectedErrorMessage));
            string? exceptionType = info.GetValue<string?>(nameof(ExpectedException));
            if (exceptionType != null)
            {
                ExpectedException = Type.GetType(exceptionType, false);
            }
        }

        /// <summary>
        /// Persist test data from xUnit Test discovery
        /// </summary>
        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(Name), Name);
            info.AddValue(nameof(WorkingDirectory), WorkingDirectory);
            info.AddValue(nameof(File), File);
            info.AddValue(nameof(LocalRepository), LocalRepository?.Length > 0 ? string.Join(";", LocalRepository) : null);
            info.AddValue(nameof(ExpectedException), $"{ExpectedException?.FullName},{ExpectedException?.Assembly.GetName().Name}");
            info.AddValue(nameof(ExpectedErrorMessage), ExpectedErrorMessage);
        } 
        #endregion

        /// <summary>
        /// Provide a display value for the testdata
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Name != null)
            {
                return Name;
            }

            // working_directory_pipeline_name
            return string.Format(
                "{0}{1}",
                WorkingDirectory,
                File == "pipeline.yml" ? "" : $"_{File.Replace(".yml","")}"
                );
        }

    }
}
