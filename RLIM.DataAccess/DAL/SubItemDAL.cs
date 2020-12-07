using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RLIM.DataAccess
{
    public class SubItemDAL : ISubItemCollectionDAL, ISubItemDAL
    {
        public void Create(SubItemDTO subItemDTO)
        {
            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "INSERT INTO dbo.SubItem (MainItemID, CertificateID, ColorID) ";
                sql += "VALUES(@mainItemID, @certificateID, @colorID)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@mainItemID", SqlDbType.Int).Value = subItemDTO.MainItemID;
                cmd.Parameters.Add("@certificateID", SqlDbType.Int).Value = subItemDTO.CertificateID;
                cmd.Parameters.Add("@colorID", SqlDbType.Int).Value = subItemDTO.ColorID;

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

        public SubItemDTO Get(int id)
        {
            SubItemDTO subItemDTO = new SubItemDTO { ID = 0 };

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.SubItem ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var certificateID = reader["CertificateID"];
                    var colorID = reader["ColorID"];

                    subItemDTO = new SubItemDTO
                    {
                        ID = (int)reader["ID"],
                        MainItemID = (int)reader["MainItemID"],
                        CertificateID = (int)certificateID,
                        ColorID = (int)colorID
                    };
                }
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }

            return subItemDTO;
        }

        public int GetID(SubItemDTO subItemDTO)
        {
            int id = 0;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT ID ";
                sql += "FROM dbo.SubItem ";
                sql += "WHERE MainItemID = @mainItemID AND CertificateID = @certificateID AND ColorID = @colorID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@mainItemID", SqlDbType.Int).Value = subItemDTO.MainItemID;
                cmd.Parameters.Add("@certificateID", SqlDbType.Int).Value = subItemDTO.CertificateID;
                cmd.Parameters.Add("@colorID", SqlDbType.Int).Value = subItemDTO.ColorID;

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = (int)reader["ID"];
                }
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }

            return id;
        }

        public List<SubItemDTO> GetAll()
        {
            List<SubItemDTO> subItemDTOs = new List<SubItemDTO>();

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.SubItem";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var certificateID = reader["CertificateID"];
                    var colorID = reader["ColorID"];

                    subItemDTOs.Add(new SubItemDTO
                    {
                        ID = (int)reader["ID"],
                        MainItemID = (int)reader["MainItemID"],
                        CertificateID = (int)certificateID,
                        ColorID = (int)colorID
                    });
                }
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }

            return subItemDTOs;
        }

        public List<SubItemDTO> GetAllWithMainItemID(int maintItemID)
        {
            List<SubItemDTO> subItemDTOs = new List<SubItemDTO>();

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.SubItem ";
                sql += "WHERE MainItemID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maintItemID;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var certificateID = reader["CertificateID"];
                    var colorID = reader["ColorID"];

                    subItemDTOs.Add(new SubItemDTO
                    {
                        ID = (int)reader["ID"],
                        MainItemID = (int)reader["MainItemID"],
                        CertificateID = (int)certificateID,
                        ColorID = (int)colorID
                    });
                }
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }

            return subItemDTOs;
        }

        public void Update(SubItemDTO subItemDTO)
        {
            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "UPDATE dbo.SubItem ";
                sql += "SET MainItemID = @mainItemID, CertificateID = @certificateID, ColorID = @colorID ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@mainItemID", SqlDbType.Int).Value = subItemDTO.MainItemID;
                cmd.Parameters.Add("@certificateID", SqlDbType.Int).Value = subItemDTO.CertificateID;
                cmd.Parameters.Add("@colorID", SqlDbType.Int).Value = subItemDTO.ColorID;

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
                string sql = "DELETE dbo.SubItem ";
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

        public void DeleteAllWithMainItemID(int maintItemID)
        {
            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "DELETE dbo.SubItem ";
                sql += "WHERE MainItemID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maintItemID;

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
