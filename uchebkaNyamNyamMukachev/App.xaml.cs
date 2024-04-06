using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using uchebkaNyamNyamMukachev.BD;


namespace uchebkaNyamNyamMukachev
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static NyamNyam_Session2_MukachevEntities BD = new NyamNyam_Session2_MukachevEntities();
        public static Dish selectedDish = new Dish();
    }
}
