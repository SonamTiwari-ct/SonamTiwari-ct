using RestApi1.DataAccess.Dapper;
using RestApi1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi1.Services
{
    public class OrderService:IOrderService
   {
        protected readonly IOrderRepo _orderRepo;
        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public void Addorder(Orders order)
        {
            _orderRepo.AddOrder(order);
        }
        public void UpdateOrder(Orders order)
        {
            _orderRepo.UpdateOrder(order);
        }
        public void DeleteOrder(int UserId)
        {
            _orderRepo.DeleteOrder(UserId);
        }
        public Task<IEnumerable<Orders>>GetAllOrderAsync()
        {
            return _orderRepo.GetAllOrdersByAsync();
        }
    }
}
