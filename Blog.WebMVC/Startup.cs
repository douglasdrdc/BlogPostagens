using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blog.WebMVC.Startup))]
namespace Blog.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
