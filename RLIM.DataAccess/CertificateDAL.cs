using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RLIM.DataAccess
{
    public class CertificateDAL : ICertificateCollectionDAL, ICertificateDAL
    {
        private static string connString = "Server=mssql.fhict.local;Database=dbi451244;User Id=dbi451244;Password=SecureW8Woord!;";
        private SqlConnection conn = new SqlConnection(connString);

        public void Create(CertificateDTO certificateDTO)
        {
            try
            {
                string sql = "INSERT INTO Certificates (Name, Tier) VALUES(@name, @tier)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = certificateDTO.Name;
                cmd.Parameters.Add("@tier", SqlDbType.Int).Value = certificateDTO.Tier;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
        }

        public CertificateDTO Get(int id)
        {
            return null;
        }

        public List<CertificateDTO> GetAll()
        {
            List<CertificateDTO> certificateDTOs = new List<CertificateDTO>();

            try
            {
                string sql = "SELECT * FROM dbo.Certificates";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CertificateDTO certificateDTO = new CertificateDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Tier = Convert.ToInt32(reader["Tier"])

                    };

                    certificateDTOs.Add(certificateDTO);
                }
            }
            catch (SqlException exception)
            {

            }

            return certificateDTOs;
        }

        public void Update(int id, string name, int tier)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
