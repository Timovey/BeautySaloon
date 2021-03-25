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
            get { return Convert.ToInt32(ComboBoxProcedures.SelectedValue); }
            set { ComboBoxProcedures.SelectedValue = value; }
        }
        public string ProcedureName { get { return ComboBoxProcedures.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(TextBoxCount.Text); }
            set
            {
                TextBoxCount.Text = value.ToString();
            }
        }

        public WindowBindingProcedure(ProcedureLogic logic)
        {
            InitializeComponent();
            List<ProcedureViewModel> list = logic.Read(null);
            if (list != null)
            {
                //ComboBoxProcedures.DisplayMember = "ComponentName";
                //ComboBoxProcedures.ValueMember = "Id";
                ComboBoxProcedures.ItemsSource = list;
                ComboBoxProcedures.SelectedItem = null;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
