﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(Shopping.AppCode.Startup1))]

namespace Shopping.AppCode
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType=DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath=new PathString("/Pages/Account/LogIn.aspx")

                });
        }
    }
}
