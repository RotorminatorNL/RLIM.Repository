using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RLIM.DataAccess
{
    public class CertificateDAL : ICertificateCollectionDAL, ICertificateDAL
    {
        public bool Create(CertificateDTO certificateDTO)
        {
            bool isCreated = false;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "INSERT INTO dbo.Certificate (Name, Tier) ";
                sql += "VALUES(@name, @tier)";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = certificateDTO.Name;
                cmd.Parameters.Add("@tier", SqlDbType.Int).Value = certificateDTO.Tier;

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

        public CertificateDTO Get(int id)
        {
            CertificateDTO certificateDTO = new CertificateDTO { ID = 0, Name = "No Certificate" };

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.Certificate ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    certificateDTO = new CertificateDTO
                    {
                        ID = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        Tier = (int)reader["Tier"]
                    };
                }
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }

            return certificateDTO;
        }

        public int GetID(CertificateDTO certificateDTO)
        {
            int id = 0;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT ID ";
                sql += "FROM dbo.Certificate ";
                sql += "WHERE Name = @name AND Tier = @tier";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = certificateDTO.Name;
                cmd.Parameters.Add("@tier", SqlDbType.Int).Value = certificateDTO.Tier;

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

        public List<CertificateDTO> GetAll()
        {
            List<CertificateDTO> certificateDTOs = new List<CertificateDTO>();

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.Certificate";
                using SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    certificateDTOs.Add(
                        new CertificateDTO 
                        { 
                            ID = (int)reader["ID"], 
                            Name = (string)reader["Name"],
                            Tier = (int)reader["Tier"]
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

            return certificateDTOs;
        }

        public bool Update(CertificateDTO certificateDTO)
        {
            bool isUpdated = false;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "UPDATE dbo.Certificate ";
                sql += "SET Name = @name, Tier = @tier ";
                sql += "WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = certificateDTO.ID;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = certificateDTO.Name;
                cmd.Parameters.Add("@tier", SqlDbType.Int).Value = certificateDTO.Tier;

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
                string sql = "DELETE dbo.Certificate ";
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
