using Dapper;
using Microsoft.Extensions.Configuration;
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
    class OrderRepo : IOrderRepo
    {
        protected readonly IConfiguration _config;

        public OrderRepo(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("OrderdbConnection"));
            }
        }
        public void AddOrder(Orders order)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"insert into Task_1(UserId,Name,Email,Mobile,Age,Date)values(@UserId,@Name,@Email,@Mobile,@Age,@Date)";
                    dbConnection.Execute(query, order);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteOrder(int UserId)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"Delete from Task_1 where UserId = @UserId";
                    dbConnection.Execute(query, new { UserId = UserId });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Orders>> GetAllOrdersByAsync()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"select * from Task_1";
                    return await dbConnection.QueryAsync<Orders>(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  async Task<Orders> GetOrderByEmail(string Email)
        {
            try
            {
                using(IDbConnection dbConnection=Connection)
                {
                    dbConnection.Open();
                    string query = @"select * from Task_1 where Email=@Email";
                    return await dbConnection.QueryFirstOrDefaultAsync<Orders>(query, new {Email=Email });
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Orders> GetOrderByUserId(int UserId)
        {
            try
            {
                using (IDbConnection dbConnection=Connection)
                {
                    dbConnection.Open();
                    string query = @"select * from Task_1 where UserId=@UserId";
                    return await dbConnection.QueryFirstOrDefaultAsync<Orders>(query, new { UserId = UserId });

                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateOrder(Orders order)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @" Update Task_1 set Name=@Name,Email=@Email,Mobile=@Mobile,Age=@Age,Date=@Date";
                    dbConnection.Execute(query, query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
