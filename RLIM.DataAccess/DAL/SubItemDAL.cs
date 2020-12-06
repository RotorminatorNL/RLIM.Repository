﻿using RLIM.ContractLayer;
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
            SubItemDTO subItemDTO = null;

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
                    subItemDTO = new SubItemDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        MainItemID = Convert.ToInt32(reader["MainItemID"]),
                        CertificateID = reader["CertificateID"].ToString() != "" ? Convert.ToInt32(reader["CertificateID"]) : 0,
                        ColorID = reader["ColorID"].ToString() != "" ? Convert.ToInt32(reader["ColorID"]) : 0
                    };
                }
                else
                {
                    subItemDTO = new SubItemDTO
                    {
                        ID = 0
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
                    subItemDTOs.Add(new SubItemDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        MainItemID = Convert.ToInt32(reader["MainItemID"]),
                        CertificateID = reader["CertificateID"].ToString() != "" ? Convert.ToInt32(reader["CertificateID"]) : 0,
                        ColorID = reader["ColorID"].ToString() != "" ? Convert.ToInt32(reader["ColorID"]) : 0
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
                    subItemDTOs.Add(new SubItemDTO
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        MainItemID = Convert.ToInt32(reader["MainItemID"]),
                        CertificateID = reader["CertificateID"].ToString() != "" ? Convert.ToInt32(reader["CertificateID"]) : 0,
                        ColorID = reader["ColorID"].ToString() != "" ? Convert.ToInt32(reader["ColorID"]) : 0
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
    }
}
