//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment3_MVC_HospitalRecords.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DoctorTbl
    {
        public DoctorTbl()
        {
            this.PatientTbls = new HashSet<PatientTbl>();
        }
    
        public int Id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    
        public virtual ICollection<PatientTbl> PatientTbls { get; set; }

        internal class Find : DoctorTbl
        {
            private int? id;

            public Find(int? id)
            {
                this.id = id;
            }
        }
    }
}
