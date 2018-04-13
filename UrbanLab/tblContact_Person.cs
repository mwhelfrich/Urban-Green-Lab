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
    
    public partial class tblContact_Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblContact_Person()
        {
            this.tblContact_Org1 = new HashSet<tblContact_Org>();
            this.tblContact_Person_Types = new HashSet<tblContact_Person_Types>();
            this.tblContact_PgmRelation_Types = new HashSet<tblContact_PgmRelation_Types>();
            this.tblEvent_Roster = new HashSet<tblEvent_Roster>();
            this.tblEvent_Info = new HashSet<tblEvent_Info>();
        }
    
        public long Person_Contact_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Name_Prefix { get; set; }
        public string Primary_Email_Id { get; set; }
        public string Addr_Street { get; set; }
        public string Addr_City { get; set; }
        public string Addr_State { get; set; }
        public string Addr_ZipCode { get; set; }
        public string Phone_Other { get; set; }
        public string Phone_Cell { get; set; }
        public Nullable<long> Intro_Contact { get; set; }
        public string Job_Title { get; set; }
        public string Notes { get; set; }
        public string Active_Ind { get; set; }
        public Nullable<long> Org_Id { get; set; }
        public string Kindful_Contact_Id { get; set; }
        public string SalesForce_Contact_Id { get; set; }
        public string Addr_Country { get; set; }
        public string Secondary_Email_Id { get; set; }
        public string Volunteer_Interest_Ind { get; set; }
        public string Address_Line_1 { get; set; }
        public string Address_Line_2 { get; set; }
        public string Address_Line_3 { get; set; }
        public string Introduced_By { get; set; }
        public Nullable<System.DateTime> Create_Datetime { get; set; }
        public Nullable<System.DateTime> Modified_Datetime { get; set; }
    
        public virtual tblContact_Org tblContact_Org { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblContact_Org> tblContact_Org1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblContact_Person_Types> tblContact_Person_Types { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblContact_PgmRelation_Types> tblContact_PgmRelation_Types { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEvent_Roster> tblEvent_Roster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEvent_Info> tblEvent_Info { get; set; }
    }
}
