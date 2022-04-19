using RestApi1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi1.DataAccess.Dapper
{
   public interface IProcOrderRepos
    {
        IEnumerable<Orders> GetAllOrder();
        IEnumerable<Orders> GetOrderByUserId(int UserId);
        IEnumerable<Orders> GetOrderByEmail(string Email);
        Response AddOrder(Orders obj);
        Response UpdateOrder(Orders order);
        Response DeleteOrder(int UserId);


    }
}
