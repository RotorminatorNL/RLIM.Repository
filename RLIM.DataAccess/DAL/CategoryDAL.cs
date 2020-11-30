using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RLIM.DataAccess
{
    public class CategoryDAL : ICategoryCollectionDAL, ICategoryDAL
    {
        public void Create(CategoryDTO categoryDTO)
        {
            try
            {
                using SqlConnection conn = Db.Connect();

                string sql = "INSERT INTO dbo.Category (Name) ";
                sql += "VALUES(@name)";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = categoryDTO.Name;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
        }

        public CategoryDTO Get(int id)
        {
            CategoryDTO categoryDTO = null;

            try
            {
                using SqlConnection conn = Db.Connect();

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
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString()
                    };
                }
                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return categoryDTO;
        }

        public List<CategoryDTO> GetAll()
        {
            List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();

            try
            {
                using SqlConnection conn = Db.Connect();

                string sql = "SELECT * FROM dbo.Category";
                using SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categoryDTOs.Add(
                        new CategoryDTO
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString()
                        });
                }
                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return categoryDTOs;
        }

        public void Update(CategoryDTO categoryDTO)
        {
            try
            {
                using SqlConnection conn = Db.Connect();

                string sql = "UPDATE dbo.Category ";
                sql += "SET Name = @name ";
                sql += "WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = categoryDTO.ID;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = categoryDTO.Name;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using SqlConnection conn = Db.Connect();

                string sql = "DELETE dbo.Category ";
                sql += "WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
