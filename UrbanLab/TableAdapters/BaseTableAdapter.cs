namespace UrbanLab.TableAdapters
{
    public class BaseTableAdapter
    {

        protected UrbanLab.UGLEntities DataContext
        {
            get
            {
                return DataContext;
            }
        }        
    }
}

