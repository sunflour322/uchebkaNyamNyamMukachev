﻿using EO.Wpf;
using EO.Wpf.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
            categ.Insert(0, new BD.Category() { Id = 0, Name = "All" });
            CategCb.ItemsSource = categ.ToList();
            CategCb.DisplayMemberPath = "Name";

            PriceRs.Minimum = App.BD.Dish.Min(i => i.FinalPriceInCents);
            PriceRs.Maximum = App.BD.Dish.Max(i => i.FinalPriceInCents);
            PriceRs.UpperValue = PriceRs.Maximum;
            PriceRs.LowerValue = PriceRs.Minimum;
            CategCb.SelectedIndex = 0;
        }
        private void Sort()
        {
            var query = App.BD.Dish.Where(i =>
                i.Name.StartsWith(NameDishTb.Text) &&
                i.FinalPriceInCents <= PriceRs.UpperValue &&
                i.FinalPriceInCents >= PriceRs.LowerValue);

            if (CategCb.SelectedIndex != 0)
            {
                query = query.Where(i => i.CategoryId == CategCb.SelectedIndex);
            }

            DishesLv.ItemsSource = new List<Dish>(query);
        }
        private void NameDishTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sort();
        }
        private void CategCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
        }
        private void PriceRs_RangeSelectionChanged(object sender, MahApps.Metro.Controls.RangeSelectionChangedEventArgs<double> e)
        {
            Sort();
        }

        private void DishesLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedDish = (Dish)DishesLv.SelectedItem;
            NavigationService.Navigate(new Recipe_for_DishesPage(App.selectedDish));
        }

        private void BlWhCb_Checked(object sender, RoutedEventArgs e)
        {
            if(BlWhCb.IsChecked == true)
            {
                foreach (var item in DishesLv.Items)
                {
                    // Проверяем выполнение условия для каждого элемента списка
                    //if ((item)) // Замените "YourCondition" на ваше условие
                    //{
                    // Получаем контейнер элемента ListView
                    var container = DishesLv.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                    if (container != null)
                    {
                        // Находим кнопку в контейнере
                        var button = container.FindName("DisplayImg") as System.Windows.Controls.Button;
                        if (button != null)
                        {
                            // Получаем изображение внутри кнопки
                            var image = button.Content as System.Windows.Controls.Image;
                            if (image != null)
                            {
                                // Применяем черно-белую фильтрацию к изображению
                                image.Effect = new GrayscaleEffect();
                            }
                        }
                    }
                    //}
                }
            }
            
           
        }
    }
}
