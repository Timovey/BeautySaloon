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
using PerformerBusinessLogic.BusinessLogic;
using PerformerBusinessLogic.ViewModels;

namespace PerformerView
{
    /// <summary>
    /// Логика взаимодействия для WindowBindingProcedure.xaml
    /// </summary>
    public partial class WindowBindingProcedure : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32((ComboBoxProcedures.SelectedItem as ProcedureViewModel).Id); }
            set { ComboBoxProcedures.SelectedItem = SetValue(value); }
        }
        public string ProcedureName { get { return (ComboBoxProcedures.SelectedItem as ProcedureViewModel).ProcedureName; } }
        public decimal ProcedurePrice { get { return (ComboBoxProcedures.SelectedItem as ProcedureViewModel).Price; } }

        public WindowBindingProcedure(ProcedureLogic logic)
        {
            InitializeComponent();
            ComboBoxProcedures.ItemsSource = logic.Read(null);

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            if (ComboBoxProcedures.SelectedValue == null)
            {
                MessageBox.Show("Выберите процедуру", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            this.DialogResult = true;
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private ProcedureViewModel SetValue(int value)
        {
            foreach(var item in ComboBoxProcedures.Items)
            {
                if((item as ProcedureViewModel).Id == value)
                {
                    return item as ProcedureViewModel;
                }
            }
            return null;
        }
    }
}
