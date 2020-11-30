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
            try
            {
                using SqlConnection conn = Db.Connect();

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
                Console.WriteLine(exception);
            }
        }

        public ColorDTO Get(int id)
        {
            ColorDTO colorDTO = null;

            try
            {
                using SqlConnection conn = Db.Connect();

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
                using SqlConnection conn = Db.Connect();

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
                Console.WriteLine(exception);
            }

            return colorDTOs;
        }

        public void Update(ColorDTO colorDTO)
        {
            try
            {
                using SqlConnection conn = Db.Connect();

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
                Console.WriteLine(exception);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using SqlConnection conn = Db.Connect();

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
                Console.WriteLine(exception);
            }
        }
    }
}
