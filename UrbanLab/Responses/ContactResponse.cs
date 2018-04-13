﻿using System;
using System.Collections.Generic;

namespace UrbanLab.Responses
{
    public class ContactOrganization:BaseResponse
    {
        public long Org_Id { get; set; }
        public string Org_Name { get; set; }
        public string Email_Id { get; set; }
        public long Primary_Contact { get; set; }
        public string Addr_Street { get; set; }
        public string Addr_City { get; set; }
        public string Addr_State { get; set; }
        public string Addr_ZipCode { get; set; }
        public string Phone_Number { get; set; }
        public string Phone_Type { get; set; }
        public DateTime Create_Datetime { get; set; }
        public DateTime Modified_Datetime { get; set; }
        public string Active_Ind { get; set; }
    }


    public class ContactPerson:BaseResponse
    {
        public long Contact_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Name_Prefix { get; set; }
        public string Email_Id { get; set; }
        public string Addr_Street { get; set; }
        public string Addr_City { get; set; }
        public string Addr_State { get; set; }
        public string Addr_ZipCode { get; set; }
        public string Phone_Work { get; set; }
        public string Phone_Cell { get; set; }
        public long Related_Contact_1 { get; set; }
        public long Related_Contact_2 { get; set; }
        public long Intro_Contact { get; set; }
        public string Title { get; set; }
        public string Related_Program { get; set; }
        public string Notes { get; set; }
        public DateTime Create_Datetime { get; set; }
        public DateTime Modified_Datetime { get; set; }
        public string Active_Ind { get; set; }
        public long? Org_Id { get; set; }
    }

    public class ContactPersonList : BaseResponse
    {
        public List<ContactPerson> ContactPeson { get; set; }
    }

    public class ContactOrganizationList : BaseResponse
    {
        public List<ContactOrganization> ContactOrganization { get; set; }
    }

    public class ContactOrgAndEvent : BaseResponse
    {
        public ContactPerson ContactPerson { get; set; }
        public List<ContactOrganization> ContactOrganization { get; set; }
        public List<EventInfo> ContactEventInfo { get; set; }

       
    }

   public class EventInfoList: BaseResponse
    {
        public List<EventInfo> EventInfo { get; set; }
    }

    public class EventInfo
    {
        public long Event_Id { get; set; }
        public int Event_Type_Id { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public DateTime Planned_Start { get; set; }
        public DateTime Planned_End { get; set; }
        public decimal Event_Duration { get; set; }
        public string Location_Name { get; set; }
        public string GPS_Location { get; set; }
        public long Primary_Contact { get; set; }
        public string Addr_Street { get; set; }
        public string Addr_City { get; set; }
        public string Addr_State { get; set; }
        public string Addr_ZipCode { get; set; }
        public DateTime Create_Datetime { get; set; }
        public DateTime Modified_Datetime { get; set; }
        public string Active_Ind { get; set; }
        public long Adult_Cnt { get; set; }
        public long Child_Cnt { get; set; }
        public decimal Mileage { get; set; }
        public decimal Average_Score { get; set; }
        public decimal Revenue { get; set; }
        public string Notes { get; set; }
        public string Photo_Release_Ind { get; set; }
        public string Photo_Code { get; set; }
        public int Involved_Org_Cnt { get; set; }        
    }
    public class ContactTypeResponse
    {
        public string ContactType { get; set; }
        public int ContactTypeID { get; set; }
    }

    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }    
}