using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using StatusBoard.Web.App_Start;

[assembly: OwinStartup(typeof(StatusBoard.Web.Startup))]
namespace StatusBoard.Web
{
    //ALL HAIL OWIN
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}