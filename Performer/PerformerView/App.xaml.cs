using Unity.Lifetime;
using System.Windows;
using PerformerBusinessLogic.BusinessLogic;
using PerformerBusinessLogic.Interfaces;
using PerformerListImplements.Implements;
using System;
using Unity;

namespace PerformerView
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
     
        //[STAThread]
        //static void Main()
        //{
        //    var container = BuildUnityContainer();
        //    //Application.EnableVisualStyles();
        //    //Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(container.Resolve<MainWindow>());
        //}
        //private static IUnityContainer BuildUnityContainer()
        //{
        //    var currentContainer = new UnityContainer();
        //    currentContainer.RegisterType<IComponentStorage, ComponentStorage>(new
        //   HierarchicalLifetimeManager());
        //    currentContainer.RegisterType<IOrderStorage, OrderStorage>(new
        //   HierarchicalLifetimeManager());
        //    currentContainer.RegisterType<IProductStorage, ProductStorage>(new
        //   HierarchicalLifetimeManager());
        //    currentContainer.RegisterType<ComponentLogic>(new
        //   HierarchicalLifetimeManager());
        //    currentContainer.RegisterType<OrderLogic>(new HierarchicalLifetimeManager());
        //    currentContainer.RegisterType<ProductLogic>(new
        //   HierarchicalLifetimeManager());
        //    return currentContainer;
        //}

    }

}
