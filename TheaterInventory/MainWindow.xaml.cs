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

namespace TheaterInventory
    {
        public partial class MainWindow : Window
        {
            private PRACTICE_LISAVEntities db;

            public MainWindow()
            {
                InitializeComponent();
                db = new PRACTICE_LISAVEntities();
                LoadData();
            }

        // Загрузка данных в DataGrid
        private void LoadData()
        {
            // Загружаем данные с включением связей
            var requisites = db.UserRequisites.Include("UserInfo").ToList();
            var costumes = db.UserCostumes.Include("UserInfo").ToList();
            var distribution = db.UseRequisitiesCostumes
                                 .Include("UserRequisites")
                                 .Include("UserCostumes")
                                 .Include("UserInfo")
                                 .ToList();

            RequisitesDataGrid.ItemsSource = requisites;
            CostumesDataGrid.ItemsSource = costumes;
            DistributionDataGrid.ItemsSource = distribution;
        }

        // Добавление нового реквизита
        private void AddRequisite_Click(object sender, RoutedEventArgs e)
            {
                var addWindow = new AddEditRequisiteWindow(new UserRequisites());
                if (addWindow.ShowDialog() == true)
                {
                    db.UserRequisites.Add(addWindow.Requisite);
                    db.SaveChanges();
                    LoadData();
                }
            }

            // Редактирование реквизита
            private void EditRequisite_Click(object sender, RoutedEventArgs e)
            {
                var selectedRequisite = RequisitesDataGrid.SelectedItem as UserRequisites;
                if (selectedRequisite != null)
                {
                    var editWindow = new AddEditRequisiteWindow(selectedRequisite);
                    if (editWindow.ShowDialog() == true)
                    {
                        db.SaveChanges();
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите реквизит для редактирования.");
                }
            }

            // Удаление реквизита
            private void DeleteRequisite_Click(object sender, RoutedEventArgs e)
            {
                var selectedRequisite = RequisitesDataGrid.SelectedItem as UserRequisites;
                if (selectedRequisite != null)
                {
                    db.UserRequisites.Remove(selectedRequisite);
                    db.SaveChanges();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Выберите реквизит для удаления.");
                }
            }

            // Добавление нового костюма
            private void AddCostume_Click(object sender, RoutedEventArgs e)
            {
                var addWindow = new AddEditCostumeWindow(new UserCostumes());
                if (addWindow.ShowDialog() == true)
                {
                    db.UserCostumes.Add(addWindow.Costume);
                    db.SaveChanges();
                    LoadData();
                }
            }

            // Редактирование костюма
            private void EditCostume_Click(object sender, RoutedEventArgs e)
            {
                var selectedCostume = CostumesDataGrid.SelectedItem as UserCostumes;
                if (selectedCostume != null)
                {
                    var editWindow = new AddEditCostumeWindow(selectedCostume);
                    if (editWindow.ShowDialog() == true)
                    {
                        db.SaveChanges();
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите костюм для редактирования.");
                }
            }

            // Удаление костюма
            private void DeleteCostume_Click(object sender, RoutedEventArgs e)
            {
                var selectedCostume = CostumesDataGrid.SelectedItem as UserCostumes;
                if (selectedCostume != null)
                {
                    db.UserCostumes.Remove(selectedCostume);
                    db.SaveChanges();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Выберите костюм для удаления.");
                }
            }
        }
    }