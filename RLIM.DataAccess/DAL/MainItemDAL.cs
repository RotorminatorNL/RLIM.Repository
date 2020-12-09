using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RLIM.DataAccess
{
    public class MainItemDAL : IMainItemCollectionDAL, IMainItemDAL
    {
        public int Create(MainItemDTO mainItemDTO)
        {
            using SqlConnection conn = Db.Connect();

            int id = 0;

            try
            {
                string sql = "INSERT INTO dbo.MainItem (Name, CategoryID, PlatformID, QualityID) ";
                sql += "VALUES(@name, @categoryID, @platformID, @qualityID) ";
                sql += "SELECT CAST(scope_identity() AS int)";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = mainItemDTO.Name;
                cmd.Parameters.Add("@categoryID", SqlDbType.Int).Value = mainItemDTO.CategoryID;
                cmd.Parameters.Add("@platformID", SqlDbType.Int).Value = mainItemDTO.PlatformID;
                cmd.Parameters.Add("@qualityID", SqlDbType.Int).Value = mainItemDTO.QualityID;

                conn.Open();
                id = (int)cmd.ExecuteScalar();
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }

            return id;
        }

        public MainItemDTO Get(int id)
        {
            MainItemDTO mainItemDTO = new MainItemDTO { ID = 0, Name = "No Main-Item" };

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.MainItem ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    mainItemDTO = new MainItemDTO
                    {
                        ID = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        CategoryID = (int)reader["CategoryID"],
                        PlatformID = (int)reader["PlatformID"],
                        QualityID = (int)reader["QualityID"]
                    };
                }
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }

            return mainItemDTO;
        }

        public int GetID(MainItemDTO mainItemDTO)
        {
            int id = 0;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT ID ";
                sql += "FROM dbo.MainItem ";
                sql += "WHERE Name = @name AND CategoryID = @categoryID AND PlatformID = @platformID AND QualityID = @qualityID";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = mainItemDTO.Name;
                cmd.Parameters.Add("@categoryID", SqlDbType.Int).Value = mainItemDTO.CategoryID;
                cmd.Parameters.Add("@platformID", SqlDbType.Int).Value = mainItemDTO.PlatformID;
                cmd.Parameters.Add("@qualityID", SqlDbType.Int).Value = mainItemDTO.QualityID;

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

        public List<MainItemDTO> GetAll()
        {
            List<MainItemDTO> mainItemDTOs = new List<MainItemDTO>();

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.MainItem";
                using SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mainItemDTOs.Add(
                        new MainItemDTO
                        {
                            ID = (int)reader["ID"],
                            Name = (string)reader["Name"],
                            CategoryID = (int)reader["CategoryID"],
                            PlatformID = (int)reader["PlatformID"],
                            QualityID = (int)reader["QualityID"]
                        });
                }
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }

            return mainItemDTOs;
        }

        public void Update(MainItemDTO mainItemDTO)
        {
            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "UPDATE dbo.MainItem ";
                sql += "SET Name = @name, CategoryID = @categoryID, PlatformID = @platformID, QualityID = @qualityID";
                sql += "WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = mainItemDTO.ID;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = mainItemDTO.Name;
                cmd.Parameters.Add("@categoryID", SqlDbType.Int).Value = mainItemDTO.CategoryID;
                cmd.Parameters.Add("@platformID", SqlDbType.Int).Value = mainItemDTO.PlatformID;
                cmd.Parameters.Add("@qualityID", SqlDbType.Int).Value = mainItemDTO.QualityID;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                conn.Close();
            }
        }

        public void Delete(int id)
        {
            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "DELETE dbo.MainItem ";
                sql += "WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
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
    }
}
