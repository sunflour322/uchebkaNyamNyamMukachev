using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            //var res = cookingSt
            //.Join(App.BD.IngredientOfStage,
            //    t1 => t1.Id,
            //    t2 => t2.CookingStageId,
            //    (t1, t2) => new
            //    {
            //        Table2Field = t2.IngredientId
            //    }).Join(App.BD.Ingredient,
            //    t2 => t2.Table2Field,
            //    t3 => t3.Id,
            //    (t2, t3) => new
            //    {
            //        Table3Field = t3.Id
            //    }).Join(App.BD.Unit,
            //    t3 => t3.Table3Field,
            //    t4 => t4.Id,
            //    (t3, t4) => new
            //    {
            //    });
            var res =  (from row1 in cookingSt
                        join row2 in App.BD.IngredientOfStage on row1.Id equals row2.CookingStageId
                        join row3 in App.BD.Ingredient on row2.IngredientId equals row3.Id
                        join row4 in App.BD.Unit on row3.UnitId equals row4.Id
                        group new { row1, row2, row3, row4 }  by row3.Name into grouped
                        select new
                        {
                            ingred = grouped.Key,
                            quan = grouped.Sum(x => x.row2.Quantity),
                            unit = grouped.Select(x => x.row4.Name),
                            cost = grouped.Sum(x => x.row3.CostInCents)
                        }).Distinct();
            IngrDg.ItemsSource = res.ToList();
             
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
