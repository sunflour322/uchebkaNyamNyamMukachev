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
using uchebkaNyamNyamMukachev.BD;

namespace uchebkaNyamNyamMukachev.Pages
{
    /// <summary>
    /// Логика взаимодействия для List_of_DishesPage.xaml
    /// </summary>
    public partial class List_of_DishesPage : Page
    {
        
        public List_of_DishesPage()
        {
            InitializeComponent();
            var categ = App.BD.Category.ToList();
            categ.Insert(0, new BD.Category() { Id = 0, Name = "Все" });
            CategCb.ItemsSource = categ.ToList();
            CategCb.DisplayMemberPath = "Name";

            DishesLv.ItemsSource = App.BD.Dish.ToList();
        }
        private void Sort()
        {
            DishesLv.ItemsSource = new List<Dish>(App.BD.Dish.Where(i => i.Name.StartsWith(NameDishTb.Text) && i.CategoryId == CategCb.SelectedIndex));
        }
        private void CostTb_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private void NameDishTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sort();
        }
        

        private void CategCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
        }
    }
}
