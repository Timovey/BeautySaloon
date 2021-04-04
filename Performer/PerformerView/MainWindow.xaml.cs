using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace PerformerView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemProcedure_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowProcedures>();
            window.ShowDialog();
        }

        private void MenuItemVisit_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowVisits>();
            window.ShowDialog();

        }
        private void MenuItemPurchase_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowPurchases>();
            window.ShowDialog();

        }

        private void MenuItemBindingReceipt_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowBindingReciept>();
            window.ShowDialog();

        }

        private void MenuItemGetList_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowDistributionList>();
            window.ShowDialog();

        }

        private void MenuItemGetReport_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
