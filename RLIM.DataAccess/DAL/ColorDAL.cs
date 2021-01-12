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
        public bool Create(ColorDTO colorDTO)
        {
            bool isCreated = false;

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

        public ColorDTO Get(int id)
        {
            ColorDTO colorDTO = new ColorDTO();

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
                        ID = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Hex = (string)reader["Hex"]
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

            return colorDTO;
        }

        public int GetID(ColorDTO colorDTO)
        {
            int id = 0;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT ID ";
                sql += "FROM dbo.Color ";
                sql += "WHERE Name = @name AND Hex = @hex";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = colorDTO.Name;
                cmd.Parameters.Add("@hex", SqlDbType.NVarChar).Value = colorDTO.Hex;

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = (int)reader["Id"];
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

        public List<ColorDTO> GetAll()
        {
            List<ColorDTO> colorDTOs = new List<ColorDTO>();

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.Color ";
                sql += "ORDER BY Name";
                using SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    colorDTOs.Add(
                        new ColorDTO
                        {
                            ID = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Hex = (string)reader["Hex"]
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

            return colorDTOs;
        }

        public bool Update(ColorDTO colorDTO)
        {
            bool isUpdated = false;

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
                string sql = "DELETE dbo.Color ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
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
