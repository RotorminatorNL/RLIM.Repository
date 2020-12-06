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
        public void Create(ColorDTO colorDTO)
        {
            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "INSERT INTO dbo.Color (Name, Hex) ";
                sql += "VALUES(@name, @hex)";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = colorDTO.Name;
                cmd.Parameters.Add("@hex", SqlDbType.NVarChar).Value = colorDTO.Hex;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }
        }

        public ColorDTO Get(int id)
        {
            ColorDTO colorDTO = null;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * FROM dbo.Color ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    colorDTO = new ColorDTO 
                    {
                        ID = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Hex = reader["Hex"].ToString()
                    };
                }
                else
                {
                    colorDTO = new ColorDTO
                    {
                        ID = 0,
                        Name = "Default"
                    };
                }
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }

            return colorDTO;
        }

        public List<ColorDTO> GetAll()
        {
            List<ColorDTO> colorDTOs = new List<ColorDTO>();

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.Color";
                using SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    colorDTOs.Add(
                        new ColorDTO 
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString(),
                            Hex = reader["Hex"].ToString()
                        });
                }
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }

            return colorDTOs;
        }

        public void Update(ColorDTO colorDTO)
        {
            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "UPDATE dbo.Color ";
                sql += "SET Name = @name, Hex = @hex ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = colorDTO.ID;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = colorDTO.Name;
                cmd.Parameters.Add("@hex", SqlDbType.NVarChar).Value = colorDTO.Hex;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }
        }

        public void Delete(int id)
        {
            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "DELETE dbo.Color ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }
        }
    }
}
