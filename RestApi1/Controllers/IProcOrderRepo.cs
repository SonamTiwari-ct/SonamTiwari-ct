using Newtonsoft.Json.Linq;
using RestApi1.Domain;
using System.Collections.Generic;

namespace RestApi1.Controllers
{
    internal interface IProcOrderRepo
    {
        Response AddOrder(Orders order);
       IEnumerable<Orders> GetAllOrder();
        IEnumerable<Orders> GetOrderByEmail(string Email);
        IEnumerable<Orders> GetOrdersByUserId(int UserId);
        Response UpdateData(Orders order);
        Response DeleteOrder(int UserId);
    }
}