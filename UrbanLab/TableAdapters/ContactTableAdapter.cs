
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Audit;
using UrbanLab.Responses;

namespace UrbanLab.TableAdapters
{
    public class ContactTableAdapter : BaseTableAdapter
    {
        #region Constructor
        public ContactTableAdapter(AuditClient auditClient) : base(auditClient)
        {

        }

        #endregion

        #region Public Methods

        public List<tblContact_Person> GetAllContacts()
        {
            misspiggyDBEntities DataContext = new misspiggyDBEntities();
            var a = (from items in DataContext.tblContact_Person
                     select items);
            if (a != null && a.Count() > 0)
            {
                return (from items in DataContext.tblContact_Person
                        select items).ToList();
            }
            else
                return null;
        }

        public BaseResponse CreateContactPerson(ContactPerson request)
        {
            misspiggyDBEntities d = new misspiggyDBEntities();
            tblContact_Person p = new tblContact_Person();

            p.Active_Ind = request.Active_Ind;
            p.Addr_City = request.Addr_City;
            p.Addr_State = request.Addr_State;
            p.Addr_Street = request.Addr_Street;
            p.Addr_ZipCode = request.Addr_ZipCode;
            p.Create_Datetime = request.Create_Datetime;
            p.Email_Id = request.Email_Id;
            p.First_Name = request.First_Name;
            p.Intro_Contact = request.Intro_Contact;
            p.Last_Name = request.Last_Name;
            p.Modified_Datetime = request.Modified_Datetime;
            p.Name_Prefix = request.Name_Prefix;
            p.Notes = request.Notes;
            p.Org_Id = request.Org_Id;
            p.Phone_Cell = request.Phone_Cell;
            p.Phone_Work = request.Phone_Work;
            p.Related_Contact_1 = request.Related_Contact_1;
            p.Related_Contact_2 = request.Related_Contact_2;
            p.Related_Program = request.Related_Program;
            p.Title = request.Title;
            p.Active_Ind = "Y";

            d.tblContact_Person.Add(p);
            BaseResponse r = new BaseResponse();
            try
            {
                d.SaveChanges();
                r.Success = true;
                r.Message = "Contact save successfull.";
            }
            catch (Exception e)
            {
                r.Success = false;
                r.Message = "Contact save unsuccessfull. Error: "+ e.Message;

            }
            return r;
        }

        public BaseResponse CreateContactOrganization(ContactOrganization request)
        {
            misspiggyDBEntities d = new misspiggyDBEntities();
            tblContact_Org p = new tblContact_Org();
            p.Active_Ind = "Y";
            p.Addr_City = request.Addr_City;
            p.Addr_State = request.Addr_State;
            p.Addr_Street = request.Addr_Street;
            p.Addr_ZipCode = request.Addr_ZipCode;
            p.Create_Datetime = request.Create_Datetime;
            p.Email_Id = request.Email_Id;
            p.Modified_Datetime = request.Modified_Datetime;
            p.Org_Name = request.Org_Name;
            p.Phone_Number = request.Phone_Number;
            p.Phone_Type = request.Phone_Type;
            p.Primary_Contact = request.Primary_Contact;
            d.tblContact_Org.Add(p);
            BaseResponse r = new BaseResponse();
            try
            {
                d.SaveChanges();
                r.Success = true;
            }
            catch (Exception e)
            {
                r.Success = false;
                r.Message = e.Message;
            }
            return r;
        }

        internal tblContact_Person GetAllDetailsByContactID(int contactID)
        {
            misspiggyDBEntities DataContext = new misspiggyDBEntities();
            var a = (from items in DataContext.tblContact_Person
                     where items.Contact_Id == contactID
                     select items);
            if (a != null && a.Count() > 0)
            {
                return (from items in DataContext.tblContact_Person
                        where items.Contact_Id == contactID                        
                        select items).FirstOrDefault();
            }
            else
                return null;

        }

        internal List<tblEvent_Info> GetAllEvents()
        {
            misspiggyDBEntities DataContext = new misspiggyDBEntities();
            var a = (from items in DataContext.tblEvent_Info
                     select items);
            if (a != null && a.Count() > 0)
            {
                return (from items in DataContext.tblEvent_Info
                        select items).ToList();
            }
            else
                return null;
        }

        internal List<tblContact_Org> GetAllOrganizations()
        {
            misspiggyDBEntities DataContext = new misspiggyDBEntities();
            var a = (from items in DataContext.tblContact_Org
                     select items);
            if (a != null && a.Count() > 0)
            {
                return (from items in DataContext.tblContact_Org
                        select items).ToList();
            }
            else
                return null;
        }

        internal tblContact_Org GetAllOrganizationByID(int OrgID)
        {
            misspiggyDBEntities DataContext = new misspiggyDBEntities();
            var a = (from items in DataContext.tblContact_Org
                     where items.Org_Id == OrgID
                     select items);
            if (a != null && a.Count() > 0)
            {
                return (from items in DataContext.tblContact_Org
                        where items.Org_Id == OrgID
                        select items).FirstOrDefault();
            }
            else
                return null;
        }

        internal BaseResponse CreateEventInfo(EventInfo request)
        {
            misspiggyDBEntities d = new misspiggyDBEntities();
            if (request != null && request.Event_Id > 0)
            {
                var ee = GetAllEventByID(request.Event_Id);
                if (ee != null)
                {                   
                    ee.Event_Type_Id = request.Event_Type_Id > 0 ? request.Event_Type_Id: ee.Event_Type_Id;
                    ee.Title = request.Title;
                    ee.Status = request.Status;
                    ee.Event_Date = request.Date;
                    ee.Planned_Start = request.Planned_Start;
                    ee.Planned_End = request.Planned_End;
                    ee.Event_Duration = request.Event_Duration;
                    ee.Location_Name = request.Location_Name;
                    ee.GPS_Location = request.GPS_Location;
                    ee.Primary_Contact = request.Primary_Contact;
                    ee.Addr_Street = request.Addr_Street;
                    ee.Addr_City = request.Addr_City;
                    ee.Addr_State = request.Addr_State;
                    ee.Addr_ZipCode = request.Addr_ZipCode;
                    ee.Create_Datetime = request.Create_Datetime;
                    ee.Modified_Datetime = request.Modified_Datetime;
                    ee.Active_Ind = request.Active_Ind;
                    ee.Adult_Cnt = request.Adult_Cnt;
                    ee.Child_Cnt = request.Child_Cnt;
                    ee.Mileage = request.Mileage;
                    ee.Average_Score = request.Average_Score;
                    ee.Revenue = request.Revenue;
                    ee.Notes = request.Notes;
                    ee.Photo_Release_Ind = request.Photo_Release_Ind;
                    ee.Photo_Code = request.Photo_Code;
                    ee.Involved_Org_Cnt = request.Involved_Org_Cnt;
                }
            }
            else
            {
                tblEvent_Info e = new tblEvent_Info();
                e.Event_Type_Id = request.Event_Type_Id;
                e.Title = request.Title;
                e.Status = request.Status;
                e.Event_Date = request.Date;
                e.Planned_Start = request.Planned_Start;
                e.Planned_End = request.Planned_End;
                e.Event_Duration = request.Event_Duration;
                e.Location_Name = request.Location_Name;
                e.GPS_Location = request.GPS_Location;
                e.Primary_Contact = request.Primary_Contact;
                e.Addr_Street = request.Addr_Street;
                e.Addr_City = request.Addr_City;
                e.Addr_State = request.Addr_State;
                e.Addr_ZipCode = request.Addr_ZipCode;
                e.Create_Datetime = request.Create_Datetime;
                e.Modified_Datetime = request.Modified_Datetime;
                e.Active_Ind = request.Active_Ind;
                e.Adult_Cnt = request.Adult_Cnt;
                e.Child_Cnt = request.Child_Cnt;
                e.Mileage = request.Mileage;
                e.Average_Score = request.Average_Score;
                e.Revenue = request.Revenue;
                e.Notes = request.Notes;
                e.Photo_Release_Ind = request.Photo_Release_Ind;
                e.Photo_Code = request.Photo_Code;
                e.Involved_Org_Cnt = request.Involved_Org_Cnt;

                d.tblEvent_Info.Add(e);
            }

            BaseResponse r = new BaseResponse();
            try
            {
                d.SaveChanges();
                r.Success = true;
                r.Message = "Successfully created Event.";
            }
            catch (Exception f)
            {
                r.Success = false;
                r.Message = "Event creation unsuccessful. Error: " + f.Message;
            }

            return r;
        }

        internal tblEvent_Info GetAllEventByID(long eventID)
        {
            misspiggyDBEntities DataContext = new misspiggyDBEntities();
            var a = (from items in DataContext.tblEvent_Info
                     where items.Event_Id == eventID
                     select items);
            if (a != null && a.Count() > 0)
            {
                return (from items in DataContext.tblEvent_Info
                        where items.Event_Id == eventID
                        select items).FirstOrDefault();
            }
            else
                return null;
        }

        #endregion
    }
}