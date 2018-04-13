
using System.Collections.Generic;
using System.Linq;
using DataAccess.Audit;
using System;

namespace UrbanLab.TableAdapters
{
    public class LookUpAdapter:BaseTableAdapter
    {


        #region Constructor
        public LookUpAdapter(AuditClient auditClient):base(auditClient)
        {

        }

        #endregion

        #region Public Methods

        public List<LU_tblContactType> GetContactType()
        {
            List<LU_tblContactType> l = new List<LU_tblContactType>();
            try
            {

                    misspiggyDBEntities DataContext = new misspiggyDBEntities();
                    return (from items in DataContext.LU_tblContactType
                             select items).ToList();
               
            }
           
            catch
            {                
                return l;
            }
        }
        

        #endregion

    }
}