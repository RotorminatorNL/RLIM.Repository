using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RLIM.DataAccess
{
    public class UserDAL : IUserCollectionDAL, IUserDAL
    {
        private List<int> GetSubItemsInventory(int id)
        {
            List<int> subItemsInventory = new List<int>();

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.Inventory ";
                sql += "WHERE UserID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    subItemsInventory.Add((int)reader["SubItemID"]);
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                conn.Close();
            }

            return subItemsInventory;
        }

        public UserDTO Get(int id)
        {
            UserDTO userDTO = new UserDTO();

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM [dbo].[User] ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userDTO = new UserDTO
                    {
                        ID = (int)reader["ID"],
                        SubItemIDs = GetSubItemsInventory((int)reader["ID"])
                    };
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                conn.Close();
            }

            return userDTO;
        }
    }
}
