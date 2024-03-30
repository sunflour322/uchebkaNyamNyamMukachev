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
using uchebkaNyamNyamMukachev.Pages;

namespace uchebkaNyamNyamMukachev
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new Pages.List_of_DishesPage());
        }

        private void Button_Click_Dishes(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.List_of_DishesPage());
        }

        private void Button_Click_Ingre(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.Recipe_for_DishesPage());

        }

        private void Button_Click_Orders(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.List_of_DishesPage());

        }
    }
}
