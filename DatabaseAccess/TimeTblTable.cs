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
    
    public partial class TimeTblTable
    {
        public int TimeTblID { get; set; }
        public int UserID { get; set; }
        public int SubjectID { get; set; }
        public System.TimeSpan StarTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public string Day { get; set; }
        public bool IsActive { get; set; }
        public int StaffID { get; set; }
        public int ClassID { get; set; }
    
        public virtual SubjectTable SubjectTable { get; set; }
        public virtual UserTable UserTable { get; set; }
        public virtual ClassTable ClassTable { get; set; }
        public virtual StaffTable StaffTable { get; set; }
    }
}
