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

namespace uchebkaNyamNyamMukachev.Pages
{
    /// <summary>
    /// Логика взаимодействия для List_of_DishesPage.xaml
    /// </summary>
    public partial class List_of_DishesPage : Page
    {
        private int count = 0;
        private int cost = 54;
        private string CostText;
        public List_of_DishesPage()
        {
            InitializeComponent();
            
            Name = "огурец";
            NameDishTb.Text = $"Recipe for '{Name}'";
            CategoryTb.Text = $"Category: {Name}";
            CookTimeTb.Text = $"Cooking time: {Name}";
            DescTb.Text = $"Short description: {Name}";
            CostTb.Text = $"Total cost: {CostText}";
        }

        private void Button_Click_Plus(object sender, RoutedEventArgs e)
        {
            CountTb.Text = Convert.ToString(count + 1);
            count++;
            CostText = Convert.ToString(count * cost);
            CostTb.Text = $"Total cost: {CostText}";
        }

        private void Button_Click_Minus(object sender, RoutedEventArgs e)
        {
            if(count > 0)
            {
                CountTb.Text = Convert.ToString(count - 1);
                count--;
                CostText = Convert.ToString(count * cost);
                CostTb.Text = $"Total cost: {CostText}";
            }
        }
    }
}
