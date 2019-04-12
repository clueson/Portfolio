using System.Windows;

namespace ComponentsDataBase
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class Application : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //enables the bootstrapper class
            //creates navigation container for the unity class and the IOC container
            base.OnStartup(e);
            var bs = new Bootstrapper();
            bs.Run();
        }
    }
}
