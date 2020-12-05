using RLIM.ContractLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RLIM.DataAccess
{
    public class QualityDAL : IQualityCollectionDAL, IQualityDAL
    {
        public void Create(QualityDTO qualityDTO)
        {
            using SqlConnection conn = Db.Connect();

            string sql = "INSERT INTO dbo.Quality (Name, Rank) ";
            sql += "VALUES(@name, @rank)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = qualityDTO.Name;
            cmd.Parameters.Add("@rank", SqlDbType.Int).Value = qualityDTO.Rank;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public QualityDTO Get(int id)
        {
            QualityDTO qualityDTO = null;

            try
            {
                using SqlConnection conn = Db.Connect();

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
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["Name"].ToString(),
                        Rank = Convert.ToInt32(reader["Rank"])
                    };
                }
                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return qualityDTO;
        }

        public List<QualityDTO> GetAll()
        {
            List<QualityDTO> qualityDTOs = new List<QualityDTO>();

            try
            {
                using SqlConnection conn = Db.Connect();

                string sql = "SELECT * ";
                sql += "FROM dbo.Quality";
                using SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    qualityDTOs.Add(
                        new QualityDTO
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString(),
                            Rank = Convert.ToInt32(reader["Rank"])
                        });
                }
                conn.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception);
            }

            return qualityDTOs;
        }

        public void Update(QualityDTO qualityDTO)
        {
            try
            {
                using SqlConnection conn = Db.Connect();

                string sql = "UPDATE dbo.Quality ";
                sql += "SET Name = @name, Rank = @rank ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = qualityDTO.ID;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = qualityDTO.Name;
                cmd.Parameters.Add("@rank", SqlDbType.Int).Value = qualityDTO.Rank;

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
                using SqlConnection conn = Db.Connect();

                string sql = "DELETE dbo.Quality ";
                sql += "WHERE ID = @id";
                using SqlCommand cmd = new SqlCommand(sql, conn);
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
