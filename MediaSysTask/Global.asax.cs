using MediaSysTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace MediaSysTask
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            List<User> users = new List<User>
            {
                new User { Id=1, Username = "Oracle", Email="admin@email.com", Password = "q", Role=UserRole.Admin },
                new User { Id=2, Username = "Neo", Email="neo@email.com", Password = "w", Role=UserRole.Regular },
            };

            Application["Users"] = users;
            Application["Tasks"] = new List<TaskItem>();
        }
    }
}