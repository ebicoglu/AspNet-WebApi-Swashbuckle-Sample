using System.Web;
using System.Web.Http;
using SwashbuckleSample.Models;

namespace SwashbuckleSample
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Insert some test values ...
            Repositories.Context.Users.Add(1, new User { Email = "alper.ebicoglu@sample.com", Id = 1, Name = "Alper Ebiçoğlu" });
            Repositories.Context.Users.Add(2, new User { Email = "mila.ebicoglu@sample.com", Id = 2, Name = "Mila Ebiçoğlu" });
        }
    }
}
