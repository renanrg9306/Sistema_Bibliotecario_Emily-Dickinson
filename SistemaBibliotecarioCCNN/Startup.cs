using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaBibliotecarioCCNN.Startup))]
namespace SistemaBibliotecarioCCNN
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
