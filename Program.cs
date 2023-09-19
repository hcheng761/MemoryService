using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace MemoryService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<Service>(s =>
                {
                    s.ConstructUsing(service => new Service());
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service => service.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("MemoryReaderService");
                x.SetDisplayName("Memory Reader Service");
                x.SetDescription("Shows list of running processes.");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
