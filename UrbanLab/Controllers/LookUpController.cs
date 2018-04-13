using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UrbanLab.Logic;
using UrbanLab.Responses;

namespace UrbanLab.Controllers
{
    public class LookUpController: ApiController
    {
        public LookUpController()
        {
        }

        [HttpGet]
        [Route("GetContactType")]
        public LookUpTypeListResponse GetContacts()
        {           
            LookUpLogic ll = new LookUpLogic();
            return ll.GetContactType();
        }

        [HttpGet]
        [Route("GetEventRole")]
        public LookUpTypeListResponse GetEventRole()
        {
            LookUpLogic ll = new LookUpLogic();
            return ll.GetEventRole();
        }

        [HttpGet]
        [Route("GetEventStatus")]
        public LookUpTypeListResponse GetEventStatus()
        {
            LookUpLogic ll = new LookUpLogic();
            return ll.GetEventStatus();
        }

        [HttpGet]
        [Route("GetEventType")]
        public LookUpTypeListResponse GetEventType()
        {
            LookUpLogic ll = new LookUpLogic();
            return ll.GetEventType();
        }

        [HttpGet]
        [Route("GetProgramRelation")]
        public LookUpTypeListResponse GetProgramRelation()
        {
            LookUpLogic ll = new LookUpLogic();
            return ll.GetProgramRelation();
        }
    }
}