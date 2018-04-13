
using System.Web.UI.WebControls;
using UrbanLab.TableAdapters;

namespace UrbanLab.Logic
{
    public class BaseLogic
    {

        protected Unit AuditClient { get; set; }

        private TableAdapters.ContactTableAdapter _contactTableAdapterproperty = null;
        protected TableAdapters.ContactTableAdapter ContactTableAdapter
        {
            get
            {
                if (_contactTableAdapterproperty == null)
                {
                    _contactTableAdapterproperty = new ContactTableAdapter(AuditClient);
                }

                return _contactTableAdapterproperty;
            }
        }

        private TableAdapters.LookUpAdapter _lookUpTableAdapterproperty = null;
        protected TableAdapters.LookUpAdapter LookUpAdapter
        {
            get
            {
                if (_lookUpTableAdapterproperty == null)
                {
                    _lookUpTableAdapterproperty = new LookUpAdapter(AuditClient);
                }

                return _lookUpTableAdapterproperty;
            }
        }
    }
}