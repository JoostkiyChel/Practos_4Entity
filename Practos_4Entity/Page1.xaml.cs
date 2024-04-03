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

namespace Practos_4Entity
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private Practos_databaseEntities1 context = new Practos_databaseEntities1();
        public Page1()
        {
            InitializeComponent();
            datasetik.ItemsSource = context.Users.ToList();
            Combo_datasetik.ItemsSource = context.Users.ToList();
            Combo_datasetik.DisplayMemberPath = "UserName";


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            datasetik.ItemsSource = context.Users.ToList().Where(item => item.UserName.Contains(search.Text));

        }

        private void Combo_datasetik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Combo_datasetik.SelectedItem != null)
            {
                var selected = Combo_datasetik.SelectedItem as Users;
                datasetik.ItemsSource = context.Users.ToList().Where(item => item.Email == selected.Email);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            datasetik.ItemsSource = context.Users.ToList();
        }
    }
}
