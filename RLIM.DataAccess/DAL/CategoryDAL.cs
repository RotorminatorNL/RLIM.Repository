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
            bool output = true;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "INSERT INTO dbo.Category (Name) ";
                sql += "VALUES(@name)";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = categoryDTO.Name;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                output = false;
                Console.WriteLine(exception);
            }
            finally
            {
                conn.Close();
            }

            return output;
        }

        public CategoryDTO Get(int id)
        {
            CategoryDTO categoryDTO = new CategoryDTO { ID = 0, Name = "No Category" };

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
                string sql = "SELECT * FROM dbo.Category";
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
            bool output = true;

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
            }
            catch (SqlException exception)
            {
                output = false;
                Console.WriteLine(exception);
            }
            finally
            {
                conn.Close();
            }

            return output;
        }

        public bool Delete(int id)
        {
            bool output = true;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "DELETE dbo.Category ";
                sql += "WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                output = false;
                Console.WriteLine(exception);
            }
            finally
            {
                conn.Close();
            }

            return output;
        }
    }
}
