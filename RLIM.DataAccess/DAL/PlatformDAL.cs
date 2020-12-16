using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RLIM.DataAccess
{
    public class PlatformDAL : IPlatformCollectionDAL, IPlatformDAL
    {
        public bool Create(PlatformDTO platformDTO)
        {
            bool isCreated = false;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "INSERT INTO dbo.Platform (Name) ";
                sql += "VALUES(@name)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = platformDTO.Name;

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

        public PlatformDTO Get(int id)
        {
            PlatformDTO platformDTO = new PlatformDTO { ID = 0, Name = "No Platform" };

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.Platform ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    platformDTO = new PlatformDTO
                    {
                        ID = (int)reader["ID"],
                        Name = (string)reader["Name"]
                    };
                }
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }

            return platformDTO;
        }

        public int GetID(PlatformDTO platformDTO)
        {
            int id = 0;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT ID ";
                sql += "FROM dbo.Platform ";
                sql += "WHERE Name = @name";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = platformDTO.Name;

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

        public List<PlatformDTO> GetAll()
        {
            List<PlatformDTO> platformDTOs = new List<PlatformDTO>();
            
            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.Platform ";
                sql += "ORDER BY Name";
                using SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    platformDTOs.Add(
                        new PlatformDTO
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

            return platformDTOs;
        }

        public bool Update(PlatformDTO platformDTO)
        {
            bool isUpdated = false;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "UPDATE dbo.Platform ";
                sql += "SET Name = @name ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = platformDTO.ID;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = platformDTO.Name;

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
                string sql = "DELETE dbo.Platform ";
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
