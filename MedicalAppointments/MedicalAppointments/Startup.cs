using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MedicalAppointments.Startup))]
namespace MedicalAppointments
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
