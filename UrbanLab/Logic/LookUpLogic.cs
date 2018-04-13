using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrbanLab.Responses;

namespace UrbanLab.Logic
{
    public class LookUpLogic:BaseLogic
    {
        public LookUpTypeListResponse GetContactType()
        {
            LookUpTypeListResponse response = new LookUpTypeListResponse();
            try
            {
                var a = LookUpAdapter.GetContactType();
                response.LookUp = new List<LookUpTypeResponse>();

                foreach (var b in a)
                {
                    LookUpTypeResponse c = new LookUpTypeResponse();
                    c.TypeDescription = b.Contact_Type_Desc;
                    c.TypeID = b.Contact_Type_Id;

                    response.LookUp.Add(c);
                }
                response.Success = true;
                response.Message = response.LookUp.Count() + " records returned.";
            }
            catch(Exception e)
            {
                response.Success = false;
                response.Message = "Error trying to retrieve ContactTypes. Error: " + e.Message;
            }            
            return response;
        }

        public LookUpTypeListResponse GetEventRole()
        {
            LookUpTypeListResponse response = new LookUpTypeListResponse();
            try
            {
                var a = LookUpAdapter.GetEventRole();
                response.LookUp = new List<LookUpTypeResponse>();

                foreach (var b in a)
                {
                    LookUpTypeResponse c = new LookUpTypeResponse();
                    c.TypeDescription = b.Event_Role_Desc;
                    c.TypeID = b.Event_Role_Id;

                    response.LookUp.Add(c);
                }
                response.Success = true;
                response.Message = response.LookUp.Count() + " records returned.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Error trying to retrieve EventRole. Error: " + e.Message;
            }
            return response;
        }

        public LookUpTypeListResponse GetEventStatus()
        {
            LookUpTypeListResponse response = new LookUpTypeListResponse();
            try
            {
                var a = LookUpAdapter.GetEventStatus();
                response.LookUp = new List<LookUpTypeResponse>();

                foreach (var b in a)
                {
                    LookUpTypeResponse c = new LookUpTypeResponse();
                    c.TypeDescription = b.Event_Status_Desc;
                    c.TypeID = b.Event_Status_Id;

                    response.LookUp.Add(c);
                }
                response.Success = true;
                response.Message = response.LookUp.Count() + " records returned.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Error trying to retrieve EventStatus. Error: " + e.Message;
            }
            return response;
        }

        public LookUpTypeListResponse GetEventType()
        {
            LookUpTypeListResponse response = new LookUpTypeListResponse();
            try
            {
                var a = LookUpAdapter.GetEventType();
                response.LookUp = new List<LookUpTypeResponse>();

                foreach (var b in a)
                {
                    LookUpTypeResponse c = new LookUpTypeResponse();
                    c.TypeDescription = b.Event_Type_Desc;
                    c.TypeID = b.Event_Type_Id;

                    response.LookUp.Add(c);
                }
                response.Success = true;
                response.Message = response.LookUp.Count() + " records returned.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Error trying to retrieve EventType. Error: " + e.Message;
            }
            return response;
        }

        public LookUpTypeListResponse GetProgramRelation()
        {
            LookUpTypeListResponse response = new LookUpTypeListResponse();
            try
            {
                var a = LookUpAdapter.GetProgramRelationType();
                response.LookUp = new List<LookUpTypeResponse>();

                foreach (var b in a)
                {
                    LookUpTypeResponse c = new LookUpTypeResponse();
                    c.TypeDescription = b.PgmRelation_Type_Desc;
                    c.TypeID = b.PgmRelation_Type_Id;

                    response.LookUp.Add(c);
                }
                response.Success = true;
                response.Message = response.LookUp.Count() + " records returned.";
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Error trying to retrieve Program Relations. Error: " + e.Message;
            }
            return response;
        }
    }
}