using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RLIM.DataAccess
{
    public class CategoryDAL : ICategoryCollectionDAL, ICategoryDAL
    {
        private readonly SqlConnection conn = Db.Connect();

        public void Create(CategoryDTO categoryDTO)
        {
            try
            {
                string sql = "INSERT INTO dbo.Category (Name) VALUES(@name)";

                SqlCommand cmd = new SqlCommand(sql, conn);
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

            // code

            return categoryDTO;
        }

        public List<CategoryDTO> GetAll()
        {
            List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();

            // code

            return categoryDTOs;
        }

        public void Update(CategoryDTO categoryDTO)
        {
            // code
        }

        public void Delete(int id)
        {
            // code
        }
    }
}
