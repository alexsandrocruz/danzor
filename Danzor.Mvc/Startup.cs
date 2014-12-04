using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Danzor.Mvc.Startup))]
namespace Danzor.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
