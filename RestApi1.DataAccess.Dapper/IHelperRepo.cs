using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi1.DataAccess.Dapper
{
   public interface IHelperRepo
    {
       public DataTable GetByProcedure(string CommandName);
      public  DataTable GetByProcedure(string CommandName, SqlParameter[] param);
      public  DataTable GetByProcedureAdapter(string CommandName, SqlParameter[] param);

    }
}
