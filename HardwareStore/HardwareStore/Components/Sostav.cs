//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HardwareStore.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sostav
    {
        public int id { get; set; }
        public Nullable<int> Order_id { get; set; }
        public Nullable<int> Product_id { get; set; }
        public Nullable<int> product_qnt { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
