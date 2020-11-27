using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RLIM.DataAccess
{
    public class SubItemDAL : ISubItemCollectionDAL, ISubItemDAL
    {
        private readonly SqlConnection conn = Db.Connect();

        public void Create(SubItemDTO subItemDTO)
        {
            // code
        }

        public SubItemDTO Get(int id)
        {
            // code
            return null;
        }

        public List<SubItemDTO> GetAll()
        {
            List<SubItemDTO> subItemDTOs = new List<SubItemDTO>();

            try
            {
                string sql = "SELECT * FROM dbo.SubItems";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SubItemDTO subItemDTO = new SubItemDTO
                    {
                        ID = Convert.ToInt32(reader["Id"]),
                        MainItemID = Convert.ToInt32(reader["MainItemId"]),
                        CertificateID = reader["CertificateId"].ToString() != "" ? Convert.ToInt32(reader["CertificateId"]) : 0,
                        ColorID = Convert.ToInt32(reader["ColorId"])
                    };

                    subItemDTOs.Add(subItemDTO);
                }

                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return subItemDTOs;
        }

        public void Update(SubItemDTO subItemDTO)
        {
            // code
        }

        public void Delete(int id)
        {
            // code
        }
    }
}
