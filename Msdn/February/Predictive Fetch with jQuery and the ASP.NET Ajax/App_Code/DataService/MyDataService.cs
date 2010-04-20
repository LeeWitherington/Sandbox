using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Threading;
using Core35.DAL;
using System.Web.Script.Services; 


/// <summary>
/// Provides some public (Web) methods for data binding
/// </summary>

namespace Core35.WebServices
{
    [WebService(Namespace = "http://core35.book/")]
    [ScriptService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class MyDataService : System.Web.Services.WebService
    {

        public MyDataService()
        {

        }

        [WebMethod]
        public Core35.DAL.Customer LookupCustomer(string id)
        {
            return Customers.Load(id);
        }

        [WebMethod]
        public Core35.DAL.Customer LookupCustomerSlow(string id)
        {
            Thread.Sleep(6000);
            return Customers.Load(id);
        }

        [WebMethod]
        public CustomerCollection LookupAllCustomers()
        {
            return Customers.LoadAll(); 
        }

        [WebMethod]
        public CustomerCollection LookupCustomers(string query)
        {
            return Customers.LoadSet(query);
        }

        [WebMethod]
        public Core35.DAL.Customer UpdateCustomer(Core35.DAL.Customer cust)
        {
            return Customers.Save(cust);
        }

        [WebMethod]
        public int VeryLengthyTask()
        {
            Thread.Sleep(7000); 
            return 1;
        }

        [WebMethod]
        public int Throw()
        {
            throw new InvalidOperationException("Exception thrown for testing purposes");
        }

        [WebMethod]
        public string FindOrdersByCustomerAsMarkup(string id)
        {
            Thread.Sleep(2000);
            return Customers.FindOrdersByCustomerAsMarkup(id);
        }
    }
}

