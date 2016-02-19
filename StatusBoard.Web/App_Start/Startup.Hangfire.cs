using Hangfire;
using Owin;
using StatusBoard.Infrastructure.Services;

namespace StatusBoard.Web
{
    public partial class Startup
    {
        private void ConfigureHangfire(IAppBuilder app)
        {
            //next three statements are for hangfire config
            // I <3 hangfire so far
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("default");

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            //now we want to register our recurring jobs that should start at app pool load
            ApplicationRecurringJobs.SetupRecurringJobs();

        }
    }
}