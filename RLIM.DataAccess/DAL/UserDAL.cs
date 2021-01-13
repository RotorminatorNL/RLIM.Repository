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

        public bool AddToInventory(int userID, int subItemID)
        {
            bool isAdded = false;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "INSERT INTO dbo.Inventory (UserID, SubItemID) ";
                sql += "VALUES(@userID, @subItemID)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                cmd.Parameters.Add("@subItemID", SqlDbType.Int).Value = subItemID;

                conn.Open();
                cmd.ExecuteNonQuery();
                isAdded = true;
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                conn.Close();
            }

            return isAdded;
        }

        public bool RemoveFromInventory(int userID, int subItemID)
        {
            bool isDeleted = false;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "DELETE dbo.Inventory ";
                sql += "WHERE UserID = @userID AND SubItemID = @subItemID";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                cmd.Parameters.Add("@subItemID", SqlDbType.Int).Value = subItemID;

                conn.Open();
                cmd.ExecuteNonQuery();
                isDeleted = true;
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                conn.Close();
            }

            return isDeleted;
        }
    }
}
