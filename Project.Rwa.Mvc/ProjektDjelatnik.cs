//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.Rwa.Mvc
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjektDjelatnik
    {
        public short IDProjektDjelatnik { get; set; }
        public short ProjektID { get; set; }
        public short DjelatnikID { get; set; }
        public Nullable<byte> RadniSatiID { get; set; }
    
        public virtual Djelatnik Djelatnik { get; set; }
        public virtual Projekt Projekt { get; set; }
        public virtual RadniSati RadniSati1 { get; set; }
    }
}
