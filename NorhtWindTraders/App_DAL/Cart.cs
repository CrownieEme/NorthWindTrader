//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NorhtWindTraders.App_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public int ItemID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<short> ProductQuantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
    }
}