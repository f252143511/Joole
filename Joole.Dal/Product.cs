//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Joole.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int Product_ID { get; set; }
        public Nullable<int> Subcategory_ID { get; set; }
        public Nullable<int> Manufacturer_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Image { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
    
        public virtual Manufacturer Manufacturer1 { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}
