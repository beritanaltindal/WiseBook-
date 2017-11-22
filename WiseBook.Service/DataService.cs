using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WiseBook.BLL.Service;

namespace WiseBook.Service
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