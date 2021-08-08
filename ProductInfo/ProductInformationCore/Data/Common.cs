using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInformationCore.Data
{
    public class Common
    {
        public static string GetConnetionString()
        {
            // Initialize the connection string builder for the underlying provider.
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = "SAGITEC-2351\\SQLEXPRESS2017";//serverName;
            sqlBuilder.InitialCatalog = "ProductInfoDB";//dbName;
            sqlBuilder.IntegratedSecurity = true;
            sqlBuilder.UserID = "";//userName;
            sqlBuilder.Password = "";//password;
            sqlBuilder.MultipleActiveResultSets = true;

            return sqlBuilder.ConnectionString;
        }
    }
}

