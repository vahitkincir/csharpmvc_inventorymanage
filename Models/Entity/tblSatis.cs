//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcStok._1.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSatis
    {
        public int satisid { get; set; }
        public Nullable<int> urun { get; set; }
        public Nullable<int> musteri { get; set; }
        public Nullable<byte> adet { get; set; }
        public Nullable<decimal> fiyat { get; set; }
    
        public virtual tblMusteriler tblMusteriler { get; set; }
        public virtual tblUrunler tblUrunler { get; set; }
    }
}
