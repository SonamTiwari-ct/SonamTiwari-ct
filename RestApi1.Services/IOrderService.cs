using RestApi1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi1.Services
{
  public  interface IOrderService
    {
        Task<IEnumerable<Orders>> GetAllOrderAsync();
        void Addorder(Orders order);
        void UpdateOrder(Orders order);
        void DeleteOrder(int UserId);

    }
}
