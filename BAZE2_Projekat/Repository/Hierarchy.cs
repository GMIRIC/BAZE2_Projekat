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
    
    public partial class Hierarchy
    {
        public int HierarchyId { get; set; }
        public int EmployeesEmployeesId { get; set; }
        public int EmployeesEmployeesId1 { get; set; }
    
        public virtual Employees Employees { get; set; }
        public virtual Employees Employees1 { get; set; }
    }
}