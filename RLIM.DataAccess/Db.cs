using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RLIM.DataAccess
{
    internal class Db
    {
        private static readonly string connString = "Server=mssql.fhict.local;Database=dbi451244;User Id=dbi451244;Password=SecureW8Woord!;";

        internal protected static SqlConnection Connect()
        {
            return new SqlConnection(connString);
        }
    }
}
