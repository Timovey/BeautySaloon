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
using PerformerBusinessLogic.ViewModels;
using PerformerBusinessLogic.BusinessLogic;
using PerformerBusinessLogic.BindingModels;
using Unity;
using System.Data;

namespace PerformerView
{
    /// <summary>
    /// Логика взаимодействия для WindowVisit.xaml
    /// </summary>
    public partial class WindowVisit : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly VisitLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> visitsProcedures;

        public WindowVisit(VisitLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void WindowVisit_Loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    VisitViewModel view = logic.Read(new VisitBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        CalendarVisit.DisplayDate = view.Date;
                        visitsProcedures = view.VisitProcedures;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                   MessageBoxImage.Error);
                }
            }
            else
            {
                visitsProcedures = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (visitsProcedures != null)
                {
                    DataGridProcedures.Columns.Clear();
                    foreach (var vp in visitsProcedures)
                    {
                        DataGridProcedures.Items.Add(vp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
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

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
