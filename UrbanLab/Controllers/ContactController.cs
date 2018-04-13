﻿using System.Web.Http;
using UrbanLab.Logic;
using UrbanLab.Responses;

namespace UrbanLab.Controllers
{
    public class ContactController : ApiController
    {
        public ContactController()
        {
        }

        [HttpGet]
        [Route("GetContact")]
        public ContactPersonList GetContacts()
        {
            ContactLogic cl = new ContactLogic();
            return cl.GetContacts();
        }

        [HttpGet]
        [Route("GetContactByID")]
        public ContactPerson GetContacts(int ContactID)
        {
            ContactLogic cl = new ContactLogic();
            return cl.GetContactByID(ContactID);
        }

        [HttpPost]
        [Route("CreateContact")]
        public BaseResponse CreateContact(ContactPerson request)
        {
            ContactLogic cl = new ContactLogic();
            return cl.CreateContact(request);
        }

        [HttpPost]
        [Route("CreateOrganization")]
        public BaseResponse CreateOrganization(ContactOrganization request)
        {
            ContactLogic cl = new ContactLogic();
            return cl.CreateOrganization(request);
        }

        [HttpGet]
        [Route("GetOrganization")]
        public ContactOrganizationList GetOrganizations()
        {
            ContactLogic cl = new ContactLogic();
            return cl.GetOrganizations();
        }

        [HttpGet]
        [Route("GetEventInfo")]
        public EventInfoList GetEventInfo()
        {
            ContactLogic cl = new ContactLogic();
            return cl.GetEventInfo();
        }

        [HttpPost]
        [Route("CreateEvent")]
        public BaseResponse CreateEvent(EventInfo request)
        {
            ContactLogic cl = new ContactLogic();
            return cl.CreateEventInfo(request);
        }
    }
}