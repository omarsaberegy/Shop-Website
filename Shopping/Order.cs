//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shopping
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public string Customer_id { get; set; }
        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public Nullable<System.DateTime> Date_ordered { get; set; }
        public bool is_in_order { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
