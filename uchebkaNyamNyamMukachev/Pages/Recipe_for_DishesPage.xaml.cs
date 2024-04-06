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
    /// Логика взаимодействия для Recipe_for_DishesPage.xaml
    /// </summary>
    public partial class Recipe_for_DishesPage : Page
    {
        private Dish dish;
        private int count;
        private int fullCost;
        public Recipe_for_DishesPage(Dish selectedDish)
        {
            InitializeComponent();
            dish = selectedDish;
            var cookingSt = App.BD.CookingStage.Where(x => x.DishId == dish.Id).ToList();
            int ct = cookingSt.Sum(x => x.TimeInMinutes.Value);
            NameDishTb.Text = $"Recipe for '{dish.Name}'";
            CategoryTb.Text = $"Category: {selectedDish.Category.Name}";
            CookTimeTb.Text = $"Cooking time: {ct} min";
            DescTb.Text = $"Short description: {dish.Description}";
            CountTb.Text = dish.BaseServingsQuantity.ToString();
            CostTb.Text = $"Total cost: {dish.FinalPriceInCents * dish.BaseServingsQuantity}";

            var ingrOfSt = App.BD.IngredientOfStage.Where(x => x.CookingStageId == cookingSt.id);
            IngrDg.ItemsSource = App.BD.Ingredient.Where(x => x.Name == dish.Name).ToList();
        }

        

        private void Button_Click_Plus(object sender, RoutedEventArgs e)
        {
            count = Convert.ToInt32(CountTb.Text);
            CountTb.Text = Convert.ToString(count + 1);
            count++;
            fullCost = count * dish.FinalPriceInCents;
            CostTb.Text = $"Total cost: {fullCost}";

        }

        private void Button_Click_Minus(object sender, RoutedEventArgs e)
        {            
            if (count > 0)
            {
                count = Convert.ToInt32(CountTb.Text);
                CountTb.Text = Convert.ToString(count - 1);
                count--;
                fullCost = count * dish.FinalPriceInCents;
                CostTb.Text = $"Total cost: {fullCost}";
            }

        }
    }
}
