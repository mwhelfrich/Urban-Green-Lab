//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UrbanLab
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblContact_PgmRelation_Types
    {
        public long PgmRelation_Id { get; set; }
        public Nullable<long> PgmRelation_Contact_Id { get; set; }
        public int PgmRelation_Type_Id { get; set; }
        public Nullable<System.DateTime> Create_Datetime { get; set; }
        public Nullable<System.DateTime> Modified_Datetime { get; set; }
    
        public virtual LU_tblPgmRelationType LU_tblPgmRelationType { get; set; }
        public virtual tblContact_Person tblContact_Person { get; set; }
    }
}