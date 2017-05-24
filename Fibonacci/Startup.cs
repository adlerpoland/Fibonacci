using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fibonacci.Startup))]
namespace Fibonacci
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
