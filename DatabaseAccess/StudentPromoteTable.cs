//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentPromoteTable
    {
        public int StudentPromoteID { get; set; }
        public int StudentID { get; set; }
        public int ClassID { get; set; }
        public int ProgramSessionID { get; set; }
        public System.DateTime PromoteDate { get; set; }
        public double AnnualFee { get; set; }
        public bool IsActive { get; set; }
        public bool IsSubmit { get; set; }
    
        public virtual ClassTable ClassTable { get; set; }
        public virtual StudentTable StudentTable { get; set; }
        public virtual ProgramSessionTable ProgramSessionTable { get; set; }
    }
}
