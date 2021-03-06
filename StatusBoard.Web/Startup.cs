﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StatusBoard.Web.Startup))]
namespace StatusBoard.Web
{
    //ALL HAIL OWIN
    public partial class Startup
    {
        //look in App_Start for the Startup partials in order to see *all* of the config
        public void Configuration(IAppBuilder app)
        {
            //authorization configuration
            ConfigureAuth(app);

            ConfigureHangfire(app);


        }
    }
}