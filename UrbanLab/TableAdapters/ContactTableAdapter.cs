
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using UrbanLab.Responses;

namespace UrbanLab.TableAdapters
{
    public class ContactTableAdapter : BaseTableAdapter
    {
        private Unit auditClient;

        public ContactTableAdapter(Unit auditClient)
        {
            this.auditClient = auditClient;
        }

        #region Public Methods

        #region Get by ID
        internal tblContact_Person GetContactByContactID(long contactID)
        {
            UGLEntities DataContext = new UGLEntities();
            var a = (from items in DataContext.tblContact_Person
                     where items.Person_Contact_Id == contactID
                     select items);
            if (a != null && a.Count() > 0)
            {
                return (from items in DataContext.tblContact_Person
                        where items.Person_Contact_Id == contactID
                        select items).FirstOrDefault();
            }
            else
                return null;
        }

        public List<IdDescription> GetContactTypeByContactID(long contactID)
        {
            UGLEntities DataContext = new UGLEntities();
            var a = (from items in DataContext.tblContact_Person_Types
                     join l in DataContext.LU_tblContactType on items.Contact_Type_Id equals l.Contact_Type_Id
                    where items.Person_Contact_Id == contactID
                    select l).ToList();

            List<IdDescription> id = new List<IdDescription>();
            foreach(var b in a)
            {
                IdDescription i = new IdDescription();
                i.Description = b.Contact_Type_Desc;
                i.ID = b.Contact_Type_Id;

                id.Add(i);
            }
            return id;
        }

        public List<IdDescription> GetContactProgramRelationByContactID(long contactID)
        {
            UGLEntities DataContext = new UGLEntities();
            var a = (from items in DataContext.tblContact_PgmRelation_Types
                     join l in DataContext.LU_tblPgmRelationType on items.PgmRelation_Type_Id equals l.PgmRelation_Type_Id
                     where items.Person_Contact_Id == contactID
                     select l).ToList();

            List<IdDescription> id = new List<IdDescription>();
            foreach (var b in a)
            {
                IdDescription i = new IdDescription();
                i.Description = b.PgmRelation_Type_Desc;
                i.ID = b.PgmRelation_Type_Id;

                id.Add(i);
            }
            return id;
        }

        internal tblContact_Org GetAllOrganizationByID(long OrgID)
        {
            UGLEntities DataContext = new UGLEntities();
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

        internal tblEvent_Info GetAllEventByID(long eventID)
        {
            UGLEntities DataContext = new UGLEntities();
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

        public List<EventContactRole> GetEventRoleByEventID(long eveID)
        {
            UGLEntities DataContext = new UGLEntities();
            var a = (from items in DataContext.tblEvent_Roster
                     where items.Event_Id == eveID
                     select items).ToList();

            List<EventContactRole> list = new List<EventContactRole>();
            foreach(var b in a)
            {
                EventContactRole role = new EventContactRole();
                role.ContactID = b.Contact_Id.Value;
                role.EventRoleID = b.Contact_Event_Role.Value;
                list.Add(role);
            }
            return list;
        }

        public string GetEventTypeByEventTypeID(int eventTypeID)
        {
            UGLEntities DataContext = new UGLEntities();
            return (from items in DataContext.LU_tblEventType
                     where items.Event_Type_Id == eventTypeID
                     select items).FirstOrDefault().Event_Type_Desc;
        }

        public string GetStatusByStatusID(int statusID)
        {
            UGLEntities DataContext = new UGLEntities();
            return (from items in DataContext.LU_tblEventStatus
                    where items.Event_Status_Id == statusID
                    select items).FirstOrDefault().Event_Status_Desc;
        }


        #endregion

        #region Create/Update/Delete

        public BaseResponse CreateContactPerson(ContactPerson request)
        {
            UGLEntities d = new UGLEntities();
            if (request != null && request.Contact_Id > 0)
            {
                var ppp = GetContactByContactID(request.Contact_Id);

                //Update
                if (ppp != null && (string.IsNullOrWhiteSpace(ppp.Active_Ind) || ppp.Active_Ind != "N"))
                {
                    var pp = d.tblContact_Person.Where(x => x.Person_Contact_Id == request.Contact_Id).FirstOrDefault();
                    pp.Addr_City = string.IsNullOrWhiteSpace(request.Addr_City)? request.Addr_City: pp.Addr_City;
                    pp.Addr_State = string.IsNullOrWhiteSpace(request.Addr_State)? request.Addr_State: pp.Addr_State;
                    pp.Addr_Street = string.IsNullOrWhiteSpace(request.Addr_Street)? request.Addr_Street:pp.Addr_Street;
                    pp.Addr_ZipCode = string.IsNullOrWhiteSpace(request.Addr_ZipCode)? request.Addr_ZipCode: pp.Addr_ZipCode;
                    pp.Create_Datetime = request.Create_Datetime> DateTime.MinValue? request.Create_Datetime: pp.Create_Datetime;
                    pp.Primary_Email_Id = string.IsNullOrWhiteSpace(request.Email_Id)? request.Email_Id: pp.Primary_Email_Id;
                    pp.First_Name = string.IsNullOrWhiteSpace(request.First_Name)? request.First_Name: pp.First_Name;
                    pp.Intro_Contact = request.Intro_Contact > 0 ? request.Intro_Contact: pp.Intro_Contact;
                    pp.Last_Name = string.IsNullOrWhiteSpace(request.Last_Name)? request.Last_Name: pp.Last_Name;
                    pp.Modified_Datetime = request.Modified_Datetime> DateTime.MinValue? request.Modified_Datetime: pp.Modified_Datetime;
                    pp.Name_Prefix = string.IsNullOrWhiteSpace(request.Name_Prefix)? request.Name_Prefix: pp.Name_Prefix;
                    pp.Notes = string.IsNullOrWhiteSpace(request.Notes)? request.Notes:pp.Notes;
                    pp.Org_Id = request.Org_Id> 0 ? request.Org_Id: pp.Org_Id;
                    pp.Phone_Cell = string.IsNullOrWhiteSpace(request.Phone_Cell)? request.Phone_Cell: pp.Phone_Cell;
                    pp.Phone_Other = string.IsNullOrWhiteSpace(request.Phone_Other)? request.Phone_Other: pp.Phone_Other;
                    pp.Job_Title = string.IsNullOrWhiteSpace(request.Job_Title)? request.Job_Title: pp.Job_Title;
                    pp.Active_Ind = "Y";
                }
                else if (ppp != null && ppp.Active_Ind == "N") //Delete
                {
                    var pp = d.tblContact_Person.Where(x => x.Person_Contact_Id == request.Contact_Id).FirstOrDefault();
                    pp.Active_Ind = "N";
                }
            }
            else
            {
                tblContact_Person p = new tblContact_Person();

                p.Active_Ind = request.Active_Ind;
                p.Addr_City = request.Addr_City;
                p.Addr_State = request.Addr_State;
                p.Addr_Street = request.Addr_Street;
                p.Addr_ZipCode = request.Addr_ZipCode;
                p.Create_Datetime = request.Create_Datetime;
                p.Primary_Email_Id = request.Email_Id;
                p.First_Name = request.First_Name;
                p.Intro_Contact = request.Intro_Contact;
                p.Last_Name = request.Last_Name;
                p.Modified_Datetime = request.Modified_Datetime;
                p.Name_Prefix = request.Name_Prefix;
                p.Notes = request.Notes;
                p.Org_Id = request.Org_Id;
                p.Phone_Cell = request.Phone_Cell;
                p.Phone_Other = request.Phone_Other;
                p.Job_Title = request.Job_Title;
                p.Active_Ind = "Y";

                d.tblContact_Person.Add(p);
            }
            BaseResponse r = new BaseResponse();
            try
            {
                d.SaveChanges();

                if (request.ContactTypeIdList != null && request.ContactTypeIdList.Count() > 0)
                {                    
                    if (request.Contact_Id > 0)
                    {
                        InsertContactPersonType(request.Contact_Id, request.ContactTypeIdList);
                    }
                    else
                    {
                        long Contact_Id = d.tblContact_Person.Where(x => x.First_Name == request.First_Name && x.Last_Name == request.Last_Name).LastOrDefault().Person_Contact_Id;
                        InsertContactPersonType(Contact_Id, request.ContactTypeIdList);
                    }
                }

                if (request.ContactProgramRelationIdList != null && request.ContactProgramRelationIdList.Count() > 0)
                {
                    if (request.Contact_Id > 0)
                    {
                        InsertContactProgramRelationType(request.Contact_Id, request.ContactProgramRelationIdList);
                    }
                    else
                    {
                        long Contact_Id = d.tblContact_Person.Where(x => x.First_Name == request.First_Name && x.Last_Name == request.Last_Name).LastOrDefault().Person_Contact_Id;
                        InsertContactProgramRelationType(Contact_Id, request.ContactProgramRelationIdList);
                    }
                }

                r.Success = true;
                r.Message = "Contact save successfull.";
            }
            catch (Exception e)
            {
                r.Success = false;
                r.Message = "Contact save unsuccessfull. Error: " + e.Message;

            }
            return r;
        }       

        public BaseResponse CreateContactOrganization(ContactOrganization request)
        {
            UGLEntities d = new UGLEntities();
            if (request != null && request.Org_Id > 0)
            {
                var ppp = GetAllOrganizationByID(request.Org_Id);
                //Update
                if (ppp != null && (string.IsNullOrWhiteSpace(ppp.Active_Ind) || ppp.Active_Ind != "N"))
                {
                    var pp = d.tblContact_Org.Where(x => x.Org_Id == request.Org_Id).FirstOrDefault();

                    pp.Active_Ind = "Y";
                    pp.Addr_City = string.IsNullOrWhiteSpace(request.Addr_City)? request.Addr_City: pp.Addr_City;
                    pp.Addr_State = string.IsNullOrWhiteSpace(request.Addr_State)? request.Addr_State: pp.Addr_State;
                    pp.Addr_Street = string.IsNullOrWhiteSpace(request.Addr_Street)? request.Addr_Street: pp.Addr_Street;
                    pp.Addr_ZipCode = string.IsNullOrWhiteSpace(request.Addr_ZipCode)? request.Addr_ZipCode: pp.Addr_ZipCode;
                    pp.Create_Datetime = request.Create_Datetime > DateTime.MinValue? request.Create_Datetime: pp.Create_Datetime;
                    pp.Email_Id = string.IsNullOrWhiteSpace(request.Email_Id)? request.Email_Id: pp.Email_Id;
                    pp.Modified_Datetime = request.Modified_Datetime > DateTime.MinValue? request.Modified_Datetime: pp.Modified_Datetime;
                    pp.Org_Name = string.IsNullOrWhiteSpace(request.Org_Name)? request.Org_Name : pp.Org_Name;
                    pp.Phone_Number = string.IsNullOrWhiteSpace(request.Phone_Number)? request.Phone_Number: pp.Phone_Number;
                    pp.Phone_Type = string.IsNullOrWhiteSpace(request.Phone_Type)? request.Phone_Type: pp.Phone_Type;
                    pp.Primary_Contact = request.Primary_Contact> 0? request.Primary_Contact: pp.Primary_Contact;
                }
                else if (ppp != null && ppp.Active_Ind == "N") //Delete
                {
                    var pp = d.tblContact_Org.Where(x => x.Org_Id == request.Org_Id).FirstOrDefault();
                    pp.Active_Ind = "N";
                }
            }
            else //Create 
            {               
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
            }
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

        internal BaseResponse CreateEventInfo(EventInfo request)
        {
            UGLEntities d = new UGLEntities();
            if (request != null && request.Event_Id > 0)
            {
                var eee = GetAllEventByID(request.Event_Id);

                //Update
                if (eee != null && (string.IsNullOrWhiteSpace(eee.Active_Ind) || eee.Active_Ind != "N"))
                {
                    var ee = d.tblEvent_Info.Where(x => x.Event_Id == request.Event_Id).FirstOrDefault();
                    ee.Event_Type_Id = request.Event_Type_Id > 0 ? request.Event_Type_Id : ee.Event_Type_Id;
                    ee.Title = !string.IsNullOrWhiteSpace(request.Title) ? request.Title : ee.Title;
                    ee.Status = request.Status > 0 ? request.Status : ee.Status;
                    ee.Event_Date = request.Date > DateTime.MinValue ? request.Date : ee.Event_Date;
                    ee.Planned_Start = request.Planned_Start > DateTime.MinValue ? request.Planned_Start : ee.Planned_Start;
                    ee.Planned_End = request.Planned_End > DateTime.MinValue ? request.Planned_End : ee.Planned_End;
                    ee.Event_Duration = request.Event_Duration != 0m ? request.Event_Duration : ee.Event_Duration;
                    ee.Location_Name = !string.IsNullOrWhiteSpace(request.Location_Name) ? request.Location_Name : ee.Location_Name;
                    ee.GPS_Location = !string.IsNullOrWhiteSpace(request.GPS_Location) ? request.GPS_Location : ee.GPS_Location;
                    ee.Primary_Contact = request.Primary_Contact > 0 ? request.Primary_Contact : ee.Primary_Contact;
                    ee.Addr_Street = !string.IsNullOrWhiteSpace(request.Addr_Street) ? request.Addr_Street : ee.Addr_Street;
                    ee.Addr_City = !string.IsNullOrWhiteSpace(request.Addr_City) ? request.Addr_City : ee.Addr_City;
                    ee.Addr_State = !string.IsNullOrWhiteSpace(request.Addr_State) ? request.Addr_State : ee.Addr_State;
                    ee.Addr_ZipCode = !string.IsNullOrWhiteSpace(request.Addr_ZipCode) ? request.Addr_ZipCode : ee.Addr_ZipCode;
                    ee.Create_Datetime = request.Create_Datetime > DateTime.MinValue ? request.Create_Datetime : ee.Create_Datetime;
                    ee.Modified_Datetime = request.Modified_Datetime > DateTime.MinValue ? request.Modified_Datetime : ee.Modified_Datetime;
                    ee.Active_Ind = "Y";
                    ee.Adult_Cnt = request.Adult_Cnt > 0 ? request.Adult_Cnt : ee.Adult_Cnt;
                    ee.Child_Cnt = request.Child_Cnt > 0 ? request.Child_Cnt : ee.Child_Cnt;
                    ee.Mileage = request.Mileage != 0m ? request.Mileage : ee.Mileage;
                    ee.Average_Score = request.Average_Score != 0m ? request.Average_Score : ee.Average_Score;
                    ee.Revenue = request.Revenue != 0m ? request.Revenue : ee.Revenue;
                    ee.Notes = !string.IsNullOrWhiteSpace(request.Notes) ? request.Notes : ee.Notes;
                    ee.Photo_Release_Ind = !string.IsNullOrWhiteSpace(request.Photo_Release_Ind) ? request.Photo_Release_Ind : ee.Photo_Release_Ind;
                    ee.Photo_Code = !string.IsNullOrWhiteSpace(request.Photo_Code) ? request.Photo_Code : ee.Photo_Code;
                    ee.Involved_Org_Cnt = request.Involved_Org_Cnt != 0 ? request.Involved_Org_Cnt : ee.Involved_Org_Cnt;

                }
                else if (eee != null && eee.Active_Ind == "N") //Delete
                {
                    var ee = d.tblEvent_Info.Where(x => x.Event_Id == request.Event_Id).FirstOrDefault();

                    ee.Active_Ind = "N";
                }
            }
            else // Create
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
                e.Active_Ind = "Y";
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
                if (request.EventContactRole != null && request.EventContactRole.Count() > 0)
                {
                    EventContactRoleList list = new EventContactRoleList();
                    if (request.Event_Id > 0)
                    {
                        list.EventID = request.Event_Id;
                    }
                    else
                    {
                        list.EventID = d.tblEvent_Info.Where(x => x.Title == request.Title).LastOrDefault().Event_Id;
                    }
                    list.EventContactRole = request.EventContactRole;
                    InsertEventRoster(list);
                }
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

        internal BaseResponse InsertEventRoster(EventContactRoleList request)
        {
            UGLEntities d = new UGLEntities();
            BaseResponse response = new BaseResponse();
            try
            {
                long eveID = request.EventID;
                if (request.EventContactRole != null && request.EventContactRole.Count() > 0)
                {
                    foreach (var a in request.EventContactRole)
                    {
                        tblEvent_Roster ev = new tblEvent_Roster();
                        ev.Event_Id = eveID;
                        ev.Contact_Id = a.ContactID;
                        ev.Contact_Event_Role = a.EventRoleID;
                        ev.Create_Datetime = DateTime.Now;
                        d.tblEvent_Roster.Add(ev);
                    }

                    d.SaveChanges();
                }
                response.Success = true;
                response.Message = "Event contact map update successful.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Event contact map update unsuccessful. Error: " + e.Message;
            }
            return response;
        }

        internal BaseResponse InsertContactPersonType(long contactID, List<IdDescription> contactTypeID)
        {
            UGLEntities d = new UGLEntities();
            BaseResponse response = new BaseResponse();
            try
            {
                if (contactTypeID != null && contactTypeID.Count() > 0)
                {
                    foreach (var a in contactTypeID)
                    {
                        tblContact_Person_Types ev = new tblContact_Person_Types();
                        ev.Person_Contact_Id = contactID;
                        ev.Contact_Type_Id = a.ID;
                        ev.Create_Datetime = DateTime.Now;
                        d.tblContact_Person_Types.Add(ev);
                    }

                    d.SaveChanges();
                }
                response.Success = true;
                response.Message = "Contact Person map update successful.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Contact Person map update unsuccessful. Error: " + e.Message;
            }
            return response;
        }

        internal BaseResponse InsertContactProgramRelationType(long contactID, List<IdDescription> PgrmRelType)
        {
            UGLEntities d = new UGLEntities();
            BaseResponse response = new BaseResponse();
            try
            {
                if (PgrmRelType != null && PgrmRelType.Count() > 0)
                {
                    foreach (var a in PgrmRelType)
                    {
                        tblContact_PgmRelation_Types ev = new tblContact_PgmRelation_Types();
                        ev.Person_Contact_Id = contactID;
                        ev.PgmRelation_Type_Id = a.ID;
                        ev.Create_Datetime = DateTime.Now;
                        d.tblContact_PgmRelation_Types.Add(ev);
                    }

                    d.SaveChanges();
                }
                response.Success = true;
                response.Message = "Contact Program relation map update successful.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Contact Program relation update unsuccessful. Error: " + e.Message;
            }
            return response;
        }

        #endregion

        #region Get ALL
        public List<tblContact_Person> GetAllContacts()
        {
            UGLEntities DataContext = new UGLEntities();
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

        internal List<tblEvent_Info> GetAllEvents()
        {
            UGLEntities DataContext = new UGLEntities();
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
            UGLEntities DataContext = new UGLEntities();
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
        #endregion

        #endregion
    }
}