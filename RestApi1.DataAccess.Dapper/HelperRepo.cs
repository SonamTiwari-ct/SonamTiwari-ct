using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi1.DataAccess.Dapper
{
   public class HelperRepo : IHelperRepo
    {
        public readonly IConfiguration _Config;
        public readonly string Configurationstr;
        public readonly string ConfigurationString;
        public HelperRepo(IConfiguration config)
        {
            _Config = config;
            ConfigurationString = this._Config.GetConnectionString("OrderdbConnection");
        }
        public DataTable GetByProcedure(string CommandName)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationString))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    DataTable dt = new DataTable();
                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        dt.Load(dataReader);
                    }
                    return dt;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }

        public DataTable GetByProcedure(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }
            using (SqlConnection conn = new SqlConnection(ConfigurationString))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                    return dt;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }

            }
        }

        public DataTable GetByProcedureAdapter(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationString))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    DataTable dt = new DataTable();
                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        dt.Load(dataReader);
                    }
                    return dt;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
    }
}
