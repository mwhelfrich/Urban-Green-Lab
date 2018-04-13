using System;
using System.Collections.Generic;
using UrbanLab.Responses;
using UrbanLab.TableAdapters;

namespace UrbanLab.Logic
{
    public class ContactLogic : BaseLogic
    {
        public ContactPersonList GetContacts()
        {
            ContactPersonList response = new ContactPersonList();
            List<ContactPerson> contactsList = new List<ContactPerson>();
            var a = ContactTableAdapter.GetAllContacts();
            try
            {
                if (a != null)
                {
                    foreach (var b in a)
                    {
                        ContactPerson c = new ContactPerson();

                        c.Active_Ind = b.Active_Ind;
                        c.Addr_City = b.Addr_City;
                        c.Addr_State = b.Addr_State;
                        c.Addr_Street = b.Addr_Street;
                        c.Addr_ZipCode = b.Addr_ZipCode;
                        c.Create_Datetime = b.Create_Datetime.HasValue ? b.Create_Datetime.Value : DateTime.Now;
                        c.Email_Id = b.Email_Id;
                        c.Modified_Datetime = b.Modified_Datetime.HasValue ? b.Modified_Datetime.Value : DateTime.MinValue;
                        c.Org_Id = b.Org_Id.HasValue ? b.Org_Id.Value : 0;
                        c.Contact_Id = b.Contact_Id;
                        c.First_Name = b.First_Name;
                        c.Intro_Contact = b.Intro_Contact.HasValue ? b.Intro_Contact.Value : 0;
                        c.Last_Name = b.Last_Name;
                        c.Name_Prefix = b.Name_Prefix;
                        c.Notes = b.Notes;
                        c.Phone_Cell = b.Phone_Cell;
                        c.Phone_Work = b.Phone_Work;
                        c.Related_Contact_1 = b.Related_Contact_1.HasValue ? b.Related_Contact_1.Value : 0;
                        c.Related_Contact_2 = b.Related_Contact_2.HasValue ? b.Related_Contact_2.Value : 0;
                        c.Related_Program = b.Related_Program;
                        c.Title = b.Title;
                        contactsList.Add(c);
                    }
                }

                response.ContactPeson = contactsList;
                response.Success = true;
                response.Message = contactsList.Count + " contacts returned.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        internal ContactPerson GetContactByID(int ContactID)
        {
            ContactPerson c = new ContactPerson();
            var b = ContactTableAdapter.GetAllDetailsByContactID(ContactID);

            try
            {
                if (b != null)
                {

                    c.Active_Ind = b.Active_Ind;
                    c.Addr_City = b.Addr_City;
                    c.Addr_State = b.Addr_State;
                    c.Addr_Street = b.Addr_Street;
                    c.Addr_ZipCode = b.Addr_ZipCode;
                    c.Create_Datetime = b.Create_Datetime.HasValue ? b.Create_Datetime.Value : DateTime.Now;
                    c.Email_Id = b.Email_Id;
                    c.Modified_Datetime = b.Modified_Datetime.HasValue ? b.Modified_Datetime.Value : DateTime.MinValue;
                    c.Org_Id = b.Org_Id.HasValue ? b.Org_Id.Value : 0;
                    c.Contact_Id = b.Contact_Id;
                    c.First_Name = b.First_Name;
                    c.Intro_Contact = b.Intro_Contact.HasValue ? b.Intro_Contact.Value : 0;
                    c.Last_Name = b.Last_Name;
                    c.Name_Prefix = b.Name_Prefix;
                    c.Notes = b.Notes;
                    c.Phone_Cell = b.Phone_Cell;
                    c.Phone_Work = b.Phone_Work;
                    c.Related_Contact_1 = b.Related_Contact_1.HasValue ? b.Related_Contact_1.Value : 0;
                    c.Related_Contact_2 = b.Related_Contact_2.HasValue ? b.Related_Contact_2.Value : 0;
                    c.Related_Program = b.Related_Program;
                    c.Title = b.Title;
                    c.Success = true;
                    c.Message = "Contact: " + c.Last_Name + " with ID: " + c.Contact_Id + "returned successfully.";
                }
            }
            catch (Exception e)
            {
                c.Success = false;
                c.Message = "Contact with ID: " + ContactID + "doesnt exist. Error: " + e.Message;
            }

            return c;
        }

        internal EventInfoList GetEventInfo()
        {
            EventInfoList response = new EventInfoList();
            List<EventInfo> eventList = new List<EventInfo>();
            var a = ContactTableAdapter.GetAllEvents();
            try
            {
                if (a != null)
                {
                    foreach (var b in a)
                    {
                        EventInfo e = new EventInfo();

                        e.Event_Id = b.Event_Id;
                        e.Event_Type_Id = b.Event_Type_Id.Value;
                        e.Title = b.Title;
                        e.Status = b.Status.Value;
                        e.Date = b.Event_Date.Value;
                        e.Planned_Start = b.Planned_Start.Value;
                        e.Planned_End = b.Planned_End.Value;
                        e.Event_Duration = b.Event_Duration.Value;
                        e.Location_Name = b.Location_Name;
                        e.GPS_Location = b.GPS_Location;
                        e.Primary_Contact = b.Primary_Contact.Value;
                        e.Addr_Street = b.Addr_Street;
                        e.Addr_City = b.Addr_City;
                        e.Addr_State = b.Addr_State;
                        e.Addr_ZipCode = b.Addr_ZipCode;
                        e.Create_Datetime = b.Create_Datetime.Value;
                        e.Modified_Datetime = b.Modified_Datetime.Value;
                        e.Active_Ind = b.Active_Ind;
                        e.Adult_Cnt = b.Adult_Cnt.Value;
                        e.Child_Cnt = b.Child_Cnt.Value;
                        e.Mileage = b.Mileage.Value;
                        e.Average_Score = b.Average_Score.Value;
                        e.Revenue = b.Revenue.Value;
                        e.Notes = b.Notes;
                        e.Photo_Release_Ind = b.Photo_Release_Ind;
                        e.Photo_Code = b.Photo_Code;
                        eventList.Add(e);
                    }
                }

                response.EventInfo = eventList;
                response.Success = true;
                response.Message = eventList.Count + " events returned.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        internal ContactOrganizationList GetOrganizations()
        {
            ContactOrganizationList response = new ContactOrganizationList();
            List<ContactOrganization> contactsList = new List<ContactOrganization>();
            var a = ContactTableAdapter.GetAllOrganizations();
            try
            {
                if (a != null)
                {
                    foreach (var b in a)
                    {
                        ContactOrganization c = new ContactOrganization();
                        c.Active_Ind = b.Active_Ind;
                        c.Addr_City = b.Addr_City;
                        c.Addr_State = b.Addr_State;
                        c.Addr_Street = b.Addr_Street;
                        c.Addr_ZipCode = b.Addr_ZipCode;
                        c.Create_Datetime = b.Create_Datetime.HasValue ? b.Create_Datetime.Value : DateTime.MinValue;
                        c.Email_Id = b.Email_Id;
                        c.Modified_Datetime = b.Modified_Datetime.HasValue ? b.Modified_Datetime.Value : DateTime.MinValue;
                        c.Org_Id = b.Org_Id;
                        c.Org_Name = b.Org_Name;
                        c.Phone_Number = b.Phone_Number;
                        c.Phone_Type = b.Phone_Type;
                        c.Primary_Contact = b.Primary_Contact.HasValue ? b.Primary_Contact.Value : 0;
                        contactsList.Add(c);
                    }
                }

                response.ContactOrganization = contactsList;
                response.Success = true;
                response.Message = contactsList.Count + " organizations returned.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        internal ContactOrganization GetOrganizationsByID(int OrgID)
        {
            ContactOrganization c = new ContactOrganization();
            var b = ContactTableAdapter.GetAllOrganizationByID(OrgID);
            try
            {
                if (b != null)
                {
                    c.Active_Ind = b.Active_Ind;
                    c.Addr_City = b.Addr_City;
                    c.Addr_State = b.Addr_State;
                    c.Addr_Street = b.Addr_Street;
                    c.Addr_ZipCode = b.Addr_ZipCode;
                    c.Create_Datetime = b.Create_Datetime.HasValue ? b.Create_Datetime.Value : DateTime.MinValue;
                    c.Email_Id = b.Email_Id;
                    c.Modified_Datetime = b.Modified_Datetime.HasValue ? b.Modified_Datetime.Value : DateTime.MinValue;
                    c.Org_Id = b.Org_Id;
                    c.Org_Name = b.Org_Name;
                    c.Phone_Number = b.Phone_Number;
                    c.Phone_Type = b.Phone_Type;
                    c.Primary_Contact = b.Primary_Contact.HasValue ? b.Primary_Contact.Value : 0;

                    c.Success = true;
                    c.Message = "Organization: " + c.Org_Name + " with ID: " + c.Org_Id + "returned successfully.";
                }
            }
            catch (Exception e)
            {
                c.Success = false;
                c.Message = "Organization with ID: " + OrgID + "doesnt exist. Error: " + e.Message;
            }

            return c;
        }

        public BaseResponse CreateOrganization(ContactOrganization request)
        {
            BaseResponse response = new BaseResponse();
            var a = ContactTableAdapter.CreateContactOrganization(request);
            return response;
        }

        public BaseResponse CreateContact(ContactPerson request)
        {
            BaseResponse response = new BaseResponse();
            var a = ContactTableAdapter.CreateContactPerson(request);
            return response;
        }

        public BaseResponse CreateEventInfo(EventInfo request)
        {
            BaseResponse response = new BaseResponse();
            var a = ContactTableAdapter.CreateEventInfo(request);
            response.Success = a.Success;
            response.Message = a.Message;
            return response;
        }
    }
}