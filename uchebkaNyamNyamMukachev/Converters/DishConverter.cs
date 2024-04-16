﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using uchebkaNyamNyamMukachev.Classes;
using uchebkaNyamNyamMukachev.BD;

namespace uchebkaNyamNyamMukachev.Classes
{
    internal class DishConverter
    {

        public static bool ReadyForCooking(Dish dishes)
        {
            var asd = dishes.BaseServingsQuantity;
            if (dishes == null)
            {
                return false;
            }
            IEnumerable<ExtendedIngredients> ingredients = IngredientToIngredient.ConvertIngredients(dishes, asd);

            bool readyForCooking = ingredients.All(x => x.IsAvailable);
            return readyForCooking;
        }
        
    }
}
