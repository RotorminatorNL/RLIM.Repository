using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RLIM.DataAccess
{
    public class CategoryDAL : ICategoryCollectionDAL, ICategoryDAL
    {
        public bool Create(CategoryDTO categoryDTO)
        {
            bool isCreated = false;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "INSERT INTO dbo.Category (Name) ";
                sql += "VALUES(@name)";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = categoryDTO.Name;

                conn.Open();
                cmd.ExecuteNonQuery();
                isCreated = true;
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                conn.Close();
            }

            return isCreated;
        }

        public CategoryDTO Get(int id)
        {
            CategoryDTO categoryDTO = new CategoryDTO();

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.Category ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    categoryDTO = new CategoryDTO
                    {
                        ID = (int)reader["ID"],
                        Name = (string)reader["Name"]
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

            return categoryDTO;
        }

        public int GetID(CategoryDTO categoryDTO)
        {
            int id = 0;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT ID ";
                sql += "FROM dbo.Category ";
                sql += "WHERE Name = @name";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = categoryDTO.Name;

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = (int)reader["ID"];
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

            return id;
        }

        public List<CategoryDTO> GetAll()
        {
            List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.Category ";
                sql += "ORDER BY Name";
                using SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categoryDTOs.Add(
                        new CategoryDTO
                        {
                            ID = (int)reader["ID"],
                            Name = (string)reader["Name"]
                        });
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

            return categoryDTOs;
        }

        public bool Update(CategoryDTO categoryDTO)
        {
            bool isUpdated = false;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "UPDATE dbo.Category ";
                sql += "SET Name = @name ";
                sql += "WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = categoryDTO.ID;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = categoryDTO.Name;

                conn.Open();
                cmd.ExecuteNonQuery();
                isUpdated = true;
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                conn.Close();
            }

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "DELETE dbo.Category ";
                sql += "WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

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
