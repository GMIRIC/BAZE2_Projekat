//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vine
    {
        public int VineId { get; set; }
        public string Name { get; set; }
        public System.DateTime ProductionDate { get; set; }
        public int WinnaryId { get; set; }
    
        public virtual Winnary Winnary { get; set; }
    }
}
