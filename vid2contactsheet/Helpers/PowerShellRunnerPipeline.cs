using Laim.LazyLogger;
using Microsoft.VisualBasic;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace vid2contactsheet.Helpers
{
    public class PowerShellRunnerPipeline
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptPath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public async Task<string> RunPowerShellScript(string scriptPath, Dictionary<string, object>? parameters)
        {
            if (!File.Exists(scriptPath))
            {
                LazyLogger.Fatal<PowerShellRunnerPipeline>($"{scriptPath} not found");
                throw new FileNotFoundException("The required PowerShell script was not found.", scriptPath);
            }

            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                runspace.Open();

                using (var powershell = PowerShell.Create())
                {
                    powershell.Runspace = runspace;
                    powershell.AddScript(File.ReadAllText(scriptPath));

                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            powershell.AddParameter(parameter.Key, parameter.Value);
                        }
                    }

                    // Prepare for capturing standard output
                    var outputCollection = new PSDataCollection<PSObject>();

                    LazyLogger.Information<PowerShellRunnerPipeline>("Invoking PowerShell command");

                    // Asynchronously invoke the script
                    var outputTask = Task.Factory.FromAsync(powershell.BeginInvoke<PSObject, PSObject>(null, outputCollection), asyncResult => powershell.EndInvoke(asyncResult));

                    // Wait for the output task to complete
                    await outputTask.ConfigureAwait(false);

                    var output = new StringBuilder();

                    // Collect standard output
                    foreach (PSObject result in outputCollection)
                    {
                        output.AppendLine(result.ToString());
                    }

                    // Collect info output from the Info stream
                    if (powershell.Streams.Information.Count > 0)
                    {
                        output.AppendLine($"Information:\r\n");
                        foreach (InformationRecord info in powershell.Streams.Information)
                        {
                            output.AppendLine(info.ToString());

                            LazyLogger.Information<PowerShellRunnerPipeline>(info.ToString());
                        }
                    }

                    if (powershell.Streams.Error.Count > 0)
                    {
                        output.AppendLine($"Errors:\r\n");
                        foreach (ErrorRecord error in powershell.Streams.Error)
                        {
                            output.AppendLine(error.ToString());

                            LazyLogger.Error<PowerShellRunnerPipeline>(error.ToString());
                        }
                    }

                    if (powershell.Streams.Warning.Count > 0)
                    {
                        output.AppendLine($"Warnings:\r\n");
                        foreach (WarningRecord warn in powershell.Streams.Warning)
                        {
                            output.AppendLine(warn.ToString());

                            LazyLogger.Warning<PowerShellRunnerPipeline>(warn.ToString());
                        }
                    }

                    LazyLogger.Debug<PowerShellRunnerPipeline>("Returning output");
                    return output.ToString();
                }
            }
        }

    }
}
