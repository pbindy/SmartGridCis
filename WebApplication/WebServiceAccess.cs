using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.myWcf;

namespace WebApplication
{
    /// <summary>
    /// Class that manages the access to the web service
    /// </summary>
    public static class WebServiceAccess
    {
        #region Properties

        private static Service1Client _myWebService;
        public static Service1Client MyWebService
        {
            get { return _myWebService ?? (_myWebService = new Service1Client()); }
        }

        #endregion
    }
}