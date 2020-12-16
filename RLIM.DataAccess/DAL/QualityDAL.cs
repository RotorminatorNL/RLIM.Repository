using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RLIM.DataAccess
{
    public class QualityDAL : IQualityCollectionDAL, IQualityDAL
    {
        public bool Create(QualityDTO qualityDTO)
        {
            bool isCreated = false;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "INSERT INTO dbo.Quality (Name, Rank) ";
                sql += "VALUES(@name, @rank)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = qualityDTO.Name;
                cmd.Parameters.Add("@rank", SqlDbType.Int).Value = qualityDTO.Rank;

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

        public QualityDTO Get(int id)
        {
            QualityDTO qualityDTO = new QualityDTO { ID = 0, Name = "No Quality" };

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.Quality ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    qualityDTO = new QualityDTO
                    {
                        ID = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        Rank = (int)reader["Rank"]
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

            return qualityDTO;
        }

        public int GetID(QualityDTO qualityDTO)
        {
            int id = 0;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT ID ";
                sql += "FROM dbo.Quality ";
                sql += "WHERE Name = @name AND Rank = @rank";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = qualityDTO.Name;
                cmd.Parameters.Add("@rank", SqlDbType.Int).Value = qualityDTO.Rank;

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

        public List<QualityDTO> GetAll()
        {
            List<QualityDTO> qualityDTOs = new List<QualityDTO>();

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "SELECT * ";
                sql += "FROM dbo.Quality ";
                sql += "ORDER BY Rank";
                using SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    qualityDTOs.Add(
                        new QualityDTO
                        {
                            ID = (int)reader["ID"],
                            Name = (string)reader["Name"],
                            Rank = (int)reader["Rank"]
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

            return qualityDTOs;
        }

        public bool Update(QualityDTO qualityDTO)
        {
            bool isUpdated = false;

            using SqlConnection conn = Db.Connect();

            try
            {
                string sql = "UPDATE dbo.Quality ";
                sql += "SET Name = @name, Rank = @rank ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = qualityDTO.ID;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = qualityDTO.Name;
                cmd.Parameters.Add("@rank", SqlDbType.Int).Value = qualityDTO.Rank;

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
                string sql = "DELETE dbo.Quality ";
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
