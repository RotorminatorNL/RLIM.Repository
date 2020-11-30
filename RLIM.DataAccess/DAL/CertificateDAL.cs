using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RLIM.DataAccess
{
    public class CertificateDAL : ICertificateCollectionDAL, ICertificateDAL
    {
        private readonly SqlConnection conn = Db.Connect();

        public void Create(CertificateDTO certificateDTO)
        {
            try
            {
                string sql = "INSERT INTO dbo.Certificate (Name, Tier) VALUES(@name, @tier)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = certificateDTO.Name;
                cmd.Parameters.Add("@tier", SqlDbType.Int).Value = certificateDTO.Tier;

                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
        }

        public CertificateDTO Get(int id)
        {
            CertificateDTO certificateDTO = null;

            try
            {
                string sql = "SELECT * FROM dbo.Certificate WHERE ID = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(); 
                
                if (reader.Read())
                {
                    certificateDTO = new CertificateDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        Tier = Convert.ToInt32(reader["Tier"])

                    };
                }

                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return certificateDTO;
        }

        public List<CertificateDTO> GetAll()
        {
            List<CertificateDTO> certificateDTOs = new List<CertificateDTO>();

            try
            {
                string sql = "SELECT * FROM dbo.Certificate";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CertificateDTO certificateDTO = new CertificateDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        Tier = Convert.ToInt32(reader["Tier"])

                    };

                    certificateDTOs.Add(certificateDTO);
                }

                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return certificateDTOs;
        }

        public void Update(CertificateDTO certificateDTO)
        {
            try
            {
                string sql = "UPDATE dbo.Certificate SET Name = @name, Tier = @tier WHERE ID = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = certificateDTO.ID;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = certificateDTO.Name;
                cmd.Parameters.Add("@tier", SqlDbType.Int).Value = certificateDTO.Tier;

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
                string sql = "DELETE dbo.Certificate WHERE ID = @id";

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
