using System.Diagnostics.CodeAnalysis;
using Hangfire;
using Microsoft.Practices.ServiceLocation;
using StatusBoard.Core.IExternalServices;
using StatusBoard.Core.IServices;

namespace StatusBoard.Infrastructure.ExternalServices
{
    /// <summary>
    /// A utility class to configure recurring jobs for HangFire, or potentially any other type of persistent queueing system
    /// </summary>
    //disable r# messages about making fx's private, as HangFire needs public methods to operate
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class ApplicationRecurringJobs
    {
        public static void SetupRecurringJobs()
        {
            Cleanup();
            RecurringJob.AddOrUpdate("ping-test", () => DoPingTestForAllHosts(), "*/5 * * * *"); //update ping test every 5 minutes
        }

        private static void Cleanup()
        {
            RecurringJob.RemoveIfExists("ping-test");
        }

        public static void DoPingTestForAllHosts()
        {
            var serverService = ServiceLocator.Current.GetInstance<IServerService>();
            var serverStatusService = ServiceLocator.Current.GetInstance<IServerStatusService>();
            foreach (var host in serverService.GetAll())
            {
                serverStatusService.PingTest(host.Hostname);
            }
        }


    }
}
