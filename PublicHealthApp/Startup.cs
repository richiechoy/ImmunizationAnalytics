﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PublicHealthApp.Startup))]
namespace PublicHealthApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}