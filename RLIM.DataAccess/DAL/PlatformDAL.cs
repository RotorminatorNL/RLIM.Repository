using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RLIM.DataAccess
{
    public class PlatformDAL : IPlatformCollectionDAL, IPlatformDAL
    {
        private readonly SqlConnection conn = Db.Connect();

        public void Create(PlatformDTO platformDTO)
        {
            try
            {
                string sql = "INSERT INTO dbo.Platform (Name) VALUES(@name)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = platformDTO.Name;

                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
        }

        public PlatformDTO Get(int id)
        {
            PlatformDTO platformDTO = null;

            // code

            return platformDTO;
        }

        public List<PlatformDTO> GetAll()
        {
            List<PlatformDTO> platformDTOs = new List<PlatformDTO>();

            // code

            return platformDTOs;
        }

        public void Update(PlatformDTO platformDTO)
        {
            // code
        }

        public void Delete(int id)
        {
            // code
        }
    }
}
