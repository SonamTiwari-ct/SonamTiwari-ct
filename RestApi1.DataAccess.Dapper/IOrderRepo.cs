using RestApi1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi1.DataAccess.Dapper
{
   public interface IOrderRepo
    {
        Task<IEnumerable<Orders>> GetAllOrdersByAsync();
        Task<Orders> GetOrderByUserId(int UserId);
        Task<Orders> GetOrderByEmail(string Email);
        void AddOrder(Orders order);
        void UpdateOrder(Orders order);
        void DeleteOrder(int UserId);
    }
}
