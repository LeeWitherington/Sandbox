using System;
// //------------------------------------------------------------------------------
// // Code disclaimer information
// // This document contains programming examples.
// // All sample code is provided for illustrative purposes only. These examples have not been thoroughly tested under all conditions. Therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
// // All programs contained herein are provided to you "AS IS" without any warranties of any kind.
// //------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPDemo.UIModel;

namespace MVPDemo.ServiceAgent
{
    public class OrderAdminServiceAgent
    {
        public List<Order> RetrieveOrders(Customer selectedCustomer, DateTime queryFrom, DateTime queryTo)
        {
            //Not to call real service. Mock up data here
            List<Order> orders = new List<Order>();

            Order order = new Order();
            order.OrderID = 1;
            order.Status = "Fulfilled";
            order.TotalPrice = 100.00M;
            order.OrderDate = new DateTime(2009, 11, 19, 9, 0, 0);
            orders.Add(order);

            order = new Order();
            order.OrderID = 2;
            order.Status = "Pending";
            order.TotalPrice = 200.00M;
            order.OrderDate = new DateTime(2009, 11, 20, 10, 10, 0);
            orders.Add(order);

            return orders;
        }
    }
}
