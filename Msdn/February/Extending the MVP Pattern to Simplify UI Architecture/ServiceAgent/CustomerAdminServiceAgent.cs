// //------------------------------------------------------------------------------
// // Code disclaimer information
// // This document contains programming examples.
// // All sample code is provided for illustrative purposes only. These examples have not been thoroughly tested under all conditions. Therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
// // All programs contained herein are provided to you "AS IS" without any warranties of any kind.
// //------------------------------------------------------------------------------

using System.Collections.Generic;
using MVPDemo.UIModel;

namespace MVPDemo.ServiceAgent {
    public class CustomerAdminServiceAgent {
        public List<Customer> RetrieveCustomers(Region selectedRegion) {
            //Not to call real service. Mock up data here
            var customers = new List<Customer>();

            var customer = new Customer();
            customer.Name = "John";
            customers.Add(customer);

            customer = new Customer();
            customer.Name = "David";
            customers.Add(customer);

            customer = new Customer();
            customer.Name = "Sue";
            customers.Add(customer);

            return customers;
        }
    }
}