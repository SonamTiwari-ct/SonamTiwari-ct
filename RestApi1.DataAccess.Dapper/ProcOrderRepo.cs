using Dapper;
using Newtonsoft.Json;
using RestApi1.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi1.DataAccess.Dapper
{
    public class ProcOrderRepo : IProcOrderRepos
    {
            protected readonly IHelperRepo _helperRepo;
              IEnumerable<Orders> result;

        public ProcOrderRepo(IHelperRepo helperRepo)
        {
            _helperRepo = helperRepo;

        }
        #region insert order
        public Response AddOrder(Orders order)
        {
            try
            {
                SqlParameter[] param = {
                  new SqlParameter("@Name" ,order.Name),
                  new SqlParameter("@Email", order.Email),
                  new SqlParameter("@Mobile" ,order.Mobile),
                  new SqlParameter("@Age" ,order.Age),

                };
                var dt = _helperRepo.GetByProcedure("SaveData", param);
                Response res = new Response();
                if (dt != null && dt.Rows.Count > 0)
                {
                    res = CommonFunction.ConvertDataTable<Response>(dt)[0];
                }
                return res;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region DeleteOrder
        public Response DeleteOrder(int UserId)
        {

            try
            {
                SqlParameter[] param = {
                    new SqlParameter("UserId",UserId),
                };
                var dt = _helperRepo.GetByProcedure("sp_DeleteData", param);
                Response res = new Response();
                if (dt != null && dt.Rows.Count > 0)
                {
                    res = CommonFunction.ConvertDataTable<Response>(dt)[0];
                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

       
        #region GetOrder By Email
        public IEnumerable<Orders> GetOrderByEmail(string Email)
        {
            try
            {
                SqlParameter[] param ={
                    new  SqlParameter("Email",Email)
                };

                
                var dt = _helperRepo.GetByProcedure("Sp_GetAllDataByEmail",param);
                if (dt != null && dt.Rows.Count > 0)
                {
                    var jsonString = JsonConvert.SerializeObject(dt, Formatting.Indented, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    result = JsonConvert.DeserializeObject<IEnumerable<Orders>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion
        #region GetOrder ByEmail
        public IEnumerable<Orders> GetOrderByUserId(int UserId)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("UserId",UserId),
                };
                var dt = _helperRepo.GetByProcedure("sp_GetAllDataByUserId",param);
                if (dt != null && dt.Rows.Count > 0)
                {
                    var jsonString = JsonConvert.SerializeObject(dt, Formatting.Indented, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    result = JsonConvert.DeserializeObject<IEnumerable<Orders>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion
        #region Update Order
        public Response UpdateOrder(Orders order)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@UserId",order.UserId),
                    new SqlParameter("@Name",order.Name),
                    new SqlParameter("@Email",order.Email),
                    new SqlParameter("@Mobile",order.Mobile),
                    new SqlParameter("@Age",order.Age),
    
                };
                var dt = _helperRepo.GetByProcedure("sp_UpdateData", param);
                Response res = new Response();
                if (dt != null && dt.Rows.Count > 0)
                {
                    res = CommonFunction.ConvertDataTable<Response>(dt)[0];
                }
                return res;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

            #region GetAll Order
            IEnumerable<Orders> IProcOrderRepos.GetAllOrder()
        {
            try
            {

                var dt = _helperRepo.GetByProcedure("Sp_GetAllData");
                if (dt != null && dt.Rows.Count > 0)
                {
                    var jsonString = JsonConvert.SerializeObject(dt, Formatting.Indented, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    result = JsonConvert.DeserializeObject<IEnumerable<Orders>>(jsonString);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion


    }
}

