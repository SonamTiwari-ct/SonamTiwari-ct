using RestApi1.DataAccess.Dapper;
using RestApi1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi1.Services
{
    public class ProcOrderService : IProcOrderservice
    {
        protected readonly IProcOrderRepos _procOrderRepo;
        public ProcOrderService(IProcOrderRepos procOrderRepo)
        { 
            _procOrderRepo = procOrderRepo;
        }
        public Response AddOrder(Orders order)
        {
            return _procOrderRepo.AddOrder(order);
        }

        public Response DeleteOrder(int UserId)
        {
            return _procOrderRepo.DeleteOrder(UserId);
        }

        public IEnumerable<Orders> GetAllOrder()
        {
            return _procOrderRepo.GetAllOrder();
        }

        public IEnumerable<Orders> GetOrderByEmail(string Email)
        {
            return _procOrderRepo.GetOrderByEmail(Email);
        }

        public IEnumerable<Orders> GetOrderByUserId(int UserId)
        {
            return _procOrderRepo.GetOrderByUserId(UserId);
        }

        public Response UpdateOrder(Orders order)
        {
            return _procOrderRepo.UpdateOrder(order);
        }
    }
}
