﻿using RLIM.ContractLayer;
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

            try
            {
                string sql = "INSERT INTO dbo.Quality (Name, Rank) ";
                sql += "VALUES(@name, @rank)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = qualityDTO.Name;
                cmd.Parameters.Add("@rank", SqlDbType.Int).Value = qualityDTO.Rank;

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
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
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
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
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
                sql += "FROM dbo.Quality";
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
                conn.Close();
            }
            catch (SqlException exception)
            {
                conn.Close();
                Console.WriteLine(exception);
            }

            return qualityDTOs;
        }

        public void Update(QualityDTO qualityDTO)
        {
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
                conn.Close();
                Console.WriteLine(exception);
            }
        }
    }
}
