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
    /// Логика взаимодействия для WindowProcedures.xaml
    /// </summary>
    public partial class WindowProcedures : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly ProcedureLogic logic;

        public WindowProcedures(ProcedureLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowProcedure>();
            if (window.ShowDialog().Value == true)
            {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridProcedures.SelectedCells.Count != 0)
            {
                var window = Container.Resolve<WindowProcedure>();
                var cellInfo = dataGridProcedures.SelectedCells[0];
                var content = (ProcedureViewModel)(cellInfo.Item);
                window.Id = Convert.ToInt32(content.Id);
                if (window.ShowDialog().Value == true)
                {
                    LoadData();
                }
               
            }
            
        }

        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {
            //if (dataGridProcedures.SelectedCells != null)
            //{
            //    var window = Container.Resolve<WindowProcedure>();
            //    window.Id = Convert.ToInt32(dataGridProcedures.SelectedCells[0].IsValid);
            //    if (window.ShowDialog().HasValue)
            //    {
            //        LoadData();
            //    }
            //}

            //if (dataGridProcedures == 1)
            //{
            //    if (MessageBox.Show("Удалить запись", "Вопрос", ,
            //   Question) == DialogResult)
            //    {
            //        int id =
            //       Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
            //        try
            //        {
            //            logic.Delete(new ComponentBindingModel { Id = id });
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
            //           MessageBoxIcon.Error);
            //        }
            //        LoadData();
            //    }
            //}
        }

        private void buttonRef_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WindowProcedures_Loaded(object sender, RoutedEventArgs e)
        {
            ProcedureBindingModel procedure = new ProcedureBindingModel()
            {
                Duration = 50,
                ProcedureName = "ads",
                Price = 500
            };
            logic.CreateOrUpdate(procedure);
            LoadData();
        }
        private void LoadData()
        {
           
            var list = logic.Read(null);
            if (list != null)
            {
                dataGridProcedures.ItemsSource = list;
                dataGridProcedures.Columns[0].Visibility = Visibility.Hidden;
            }
        }
    }
}
