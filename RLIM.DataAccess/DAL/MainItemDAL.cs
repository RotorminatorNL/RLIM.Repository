using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RLIM.DataAccess
{
    public class MainItemDAL : IMainItemCollectionDAL, IMainItemDAL
    {
        private readonly SqlConnection conn = Db.Connect();

        public void Create(MainItemDTO mainItemDTO)
        {
            try
            {
                string sql = @"INSERT INTO dbo.MainItem (Name, CategoryID, PlatformID, QualityID) 
                               VALUES(@name, @categoryID, @platformID, @qualityID)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = mainItemDTO.Name;
                cmd.Parameters.Add("@categoryID", SqlDbType.Int).Value = mainItemDTO.CategoryID;
                cmd.Parameters.Add("@platformID", SqlDbType.Int).Value = mainItemDTO.PlatformID;
                cmd.Parameters.Add("@qualityID", SqlDbType.Int).Value = mainItemDTO.QualityID;

                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
        }

        public MainItemDTO Get(int id)
        {
            MainItemDTO mainItemDTO = null;

            // code

            return mainItemDTO;
        }

        public List<MainItemDTO> GetAll()
        {
            List<MainItemDTO> mainItemDTOs = new List<MainItemDTO>();

            // code

            return mainItemDTOs;
        }

        public void Update(MainItemDTO mainItemDTO)
        {
            // code
        }

        public void Delete(int id)
        {
            // code
        }
    }
}
