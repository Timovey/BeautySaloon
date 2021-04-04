using BeautySaloonBusinessLogic.BusinessLogics;
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
using System.Windows.Shapes;
using Unity;

namespace BeautySaloon
{
    /// <summary>
    /// Логика взаимодействия для WindowReceipts.xaml
    /// </summary>
    public partial class WindowReceipts : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }

        private int? id;

        private readonly ReceiptLogic logic;

        public WindowReceipts(ReceiptLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void WindowReceipts_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonUpd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonRef_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
