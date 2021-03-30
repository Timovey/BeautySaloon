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
            if (window.ShowDialog().Value == true)
            {
                LoadData();
            }
        }

        private void MenuItemVisit_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowVisits>();
            if (window.ShowDialog().Value == true)
            {
                LoadData();
            }
        }
        private void LoadData()
        {

        }

        private void MenuItemPurchase_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowPurchases>();
            if (window.ShowDialog().Value == true)
            {
                LoadData();
            }
        }

        private void MenuItemBindingReceipt_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowBindingReciept>();
            if (window.ShowDialog().Value == true)
            {
                LoadData();
            }
        }

        private void MenuItemGetList_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowDistributionList>();
            if (window.ShowDialog().Value == true)
            {
                LoadData();
            }
        }

        private void MenuItemGetReport_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
