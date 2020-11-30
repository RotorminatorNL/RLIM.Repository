using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RLIM.DataAccess
{
    public class ColorDAL : IColorCollectionDAL, IColorDAL
    {
        private readonly SqlConnection conn = Db.Connect();

        public void Create(ColorDTO colorDTO)
        {
            try
            {
                string sql = "INSERT INTO dbo.Color (Name, Hex) VALUES(@name, @hex)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = colorDTO.Name;
                cmd.Parameters.Add("@hex", SqlDbType.NVarChar).Value = colorDTO.Hex;

                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
        }

        public ColorDTO Get(int id)
        {
            ColorDTO colorDTO = null;

            try
            {
                string sql = "SELECT * FROM dbo.Color WHERE ID = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    colorDTO = new ColorDTO
                    {
                        ID = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Hex = reader["Hex"].ToString()

                    };
                }

                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return colorDTO;
        }

        public List<ColorDTO> GetAll()
        {
            List<ColorDTO> colorDTOs = new List<ColorDTO>();

            try
            {
                string sql = "SELECT * FROM dbo.Color";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ColorDTO colorDTO = new ColorDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        Hex = reader["Hex"].ToString()

                    };

                    colorDTOs.Add(colorDTO);
                }

                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return colorDTOs;
        }

        public void Update(ColorDTO colorDTO)
        {
            try
            {
                string sql = "UPDATE dbo.Color SET Name = @name, Hex = @hex WHERE ID = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = colorDTO.ID;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = colorDTO.Name;
                cmd.Parameters.Add("@hex", SqlDbType.NVarChar).Value = colorDTO.Hex;

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
                string sql = "DELETE dbo.Color WHERE Id = @id";

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
