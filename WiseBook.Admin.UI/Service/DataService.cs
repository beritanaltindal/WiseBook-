using WiseBook.BLL.Service;

namespace WiseBook.Admin.UI.Service
{
    public sealed class DataService
    {
        private static readonly EntityService service = new EntityService();

        public static EntityService Service
        {
            get
            {
                return service;
            }
        }

    }
}