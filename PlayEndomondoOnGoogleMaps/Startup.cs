using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlayEndomondoOnGoogleMaps.Startup))]
namespace PlayEndomondoOnGoogleMaps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
