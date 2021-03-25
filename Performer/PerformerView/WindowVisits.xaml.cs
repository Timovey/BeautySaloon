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
    /// Логика взаимодействия для WindowVisits.xaml
    /// </summary>
    public partial class WindowVisits : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly VisitLogic logic;

        public WindowVisits(VisitLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowVisit>();
            if (window.ShowDialog().Value == true)
            {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridVisits.SelectedCells.Count != 0)
            {
                var window = Container.Resolve<WindowVisit>();
                var cellInfo = dataGridVisits.SelectedCells[0];
                VisitViewModel content = (VisitViewModel)(cellInfo.Item);
                window.Id = Convert.ToInt32(content.Id);
                if (window.ShowDialog().Value == true)
                {
                    LoadData();
                }

            }
        }

        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridVisits.SelectedCells.Count != 0)
            {
                var result = MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo,
               MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var cellInfo = dataGridVisits.SelectedCells[0];
                    VisitViewModel content = (VisitViewModel)(cellInfo.Item);
                    int id = Convert.ToInt32(content.Id);
                    try
                    {
                        logic.Delete(new VisitBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                       MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        
        private void WindowVisits_Loaded(object sender, RoutedEventArgs e)
        {
            VisitBindingModel visit = new VisitBindingModel()
            {
                Date = DateTime.Now,
            };
            logic.CreateOrUpdate(visit);
            LoadData();
        }
        private void LoadData()
        {

            var list = logic.Read(null);
            if (list != null)
            {
                dataGridVisits.ItemsSource = list;
                dataGridVisits.Columns[0].Visibility = Visibility.Hidden;
            }
        }
    }
}
