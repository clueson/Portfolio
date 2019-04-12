using System.Windows;
using Prism.Unity;
using Microsoft.Practices.Unity;
using ComponentsDataBase.Views;

namespace ComponentsDataBase
{
    /// <summary>
    /// Generated and coded by C.Coulson from an earlier Menu system designed in 2010
    /// to test out ideas of control templating to alter the styles,
    /// and adding MVVM, Prism, Unity, and using the prism event system, messaging and behaviours,
    /// and commanding, to extend the original application.
    /// The application wa soriginally intended only as a front end implementation to  have 
    /// at a later stage an entity framweork database attached in the cloud and
    /// webscraping data to fill it and be displayed in this application.
    /// </summary>
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            //resolver for Prism and container creation
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            //creates the container and loads the shell containing the Content.
            System.Windows.Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            //was used to pre instatiate type and then inject into a Xaml page
            //Container.RegisterType(typeof(object), typeof(ViewA), "ViewA");
            //Container.RegisterType(typeof(object), typeof(ViewB), "ViewB");
            //Container.RegisterTypeForNavigation<ViewMenuBar>("ViewMenuBar");
            //Container.RegisterTypeForNavigation<ViewSearchTextBox>("ViewSearchTextBox");

            //Container.RegisterType<ViewMenuBar>("ViewMenuBar");
            //Container.RegisterType<ViewButtonsRibbon>("ViewButtonsRibbon");
            //Container.RegisterType<ViewLeftListBox>("ViewLeftListBox");
            //Container.RegisterType<ViewRightListBox>("ViewRightListBox");
            //Container.RegisterType(typeof(object), typeof(ViewMenuBar), "ViewMenuBar");
            //Container.RegisterType(typeof(object), typeof(ViewStatusBar), "ViewStatusBar");
            //Container.RegisterTypeForNavigation<ViewTestControl>("ViewTestControl");
        }

    }
    public static class UnityExtensions
    {
        public static void RegisterTypeForNavigation<T>(this IUnityContainer container, string name)
        {
            container.RegisterType(typeof(object), typeof(T), name);
        }
       
    }
}
