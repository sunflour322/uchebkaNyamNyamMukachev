//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace uchebkaNyamNyamMukachev.BD
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderedDish
    {
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public Nullable<int> ServingsNumber { get; set; }
        public Nullable<System.DateTime> StartCookingDT { get; set; }
        public Nullable<System.DateTime> EndCookingDT { get; set; }
    
        public virtual Dish Dish { get; set; }
        public virtual Order Order { get; set; }
    }
}
