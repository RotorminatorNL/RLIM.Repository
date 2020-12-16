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
        public bool Create(SubItemDTO subItemDTO)
        {
            bool isCreated = false;

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
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                conn.Close();
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

        public List<SubItemDTO> GetAll()
        {
            List<SubItemDTO> subItemDTOs = new List<SubItemDTO>();

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.SubItem ";
                sql += "ORDER BY Name";
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
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                conn.Close();
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
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                conn.Close();
            }

            return subItemDTOs;
        }

        public bool Update(SubItemDTO subItemDTO)
        {
            bool isUpdated = false;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "UPDATE dbo.SubItem ";
                sql += "SET CertificateID = @certificateID, ColorID = @colorID ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = subItemDTO.ID;
                cmd.Parameters.Add("@certificateID", SqlDbType.Int).Value = subItemDTO.CertificateID;
                cmd.Parameters.Add("@colorID", SqlDbType.Int).Value = subItemDTO.ColorID;

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
                string sql = "DELETE dbo.SubItem ";
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

        public bool DeleteAllWithMainItemID(int maintItemID)
        {
            bool areAllDeleted = false;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "DELETE dbo.SubItem ";
                sql += "WHERE MainItemID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = maintItemID;

                conn.Open();
                cmd.ExecuteNonQuery();
                areAllDeleted = true;
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                conn.Close();
            }

            return areAllDeleted;
        }
    }
}
