using RestApi1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi1.Services
{
   public  interface IProcOrderservice
    {
        Response AddOrder(Orders obj);
        IEnumerable<Orders> GetAllOrder();
        IEnumerable<Orders> GetOrderByEmail(string Email);
        IEnumerable<Orders> GetOrderByUserId(int UserId);
        Response DeleteOrder(int UserId);
        Response UpdateOrder(Orders order);
    }
}
