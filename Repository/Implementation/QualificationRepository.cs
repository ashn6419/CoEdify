using ApplicationCore;
using DomainModels.Entities;
using Microsoft.Extensions.Configuration;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Repository.Implementation
{
    public class QualificationRepository : Repository<Qualification>, IQualificationRepository
    {
        readonly public string constr = string.Empty;
        public QualificationRepository(IConfiguration configuration) : base(configuration)
        {
            constr = dbCon.GetConnection();
        }
        public int AddQualification(Qualification qualification)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "InsertQualification";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@QualificationName", qualification.QualificationName);
                    cmd.Parameters.AddWithValue("@Descritpion", qualification.Description);
                    cmd.Parameters.AddWithValue("@CreatedDate", qualification.CreatedDate);
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Direction = ParameterDirection.Output;

                    con.Open();
                    result = cmd.ExecuteNonQuery();

                    if (cmd.Parameters["@Id"].Value != DBNull.Value)
                    {
                        qualification.QualificationId = Convert.ToInt32(cmd.Parameters["@Id"].Value);
                        result = qualification.QualificationId;
                    }
                }
                catch (Exception ex)
                {
                    return -2;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return result;
            }
        }

        public int DeleteQualification(int Id)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_DeleteQualification";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QualificationId", Id);

                    con.Open();

                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return -2;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

                return result;
            }
        }

        public IEnumerable<Qualification> GetAll()
        {
            List<Qualification> qualifications = new List<Qualification>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_GetAllQualifications";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Qualification qualification = new Qualification();
                                qualification.QualificationId = Convert.ToInt32(reader["Id"]);
                                qualification.QualificationName = reader["QualificationName"].ToString();
                                qualification.Description = reader["Description"].ToString();
                                if (reader["CreatedDate"] != DBNull.Value)
                                    qualification.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                if (reader["ModifiedDate"] != DBNull.Value)
                                    qualification.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                                qualifications.Add(qualification);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return qualifications;
            }
        }

        public Qualification GetQualificationById(int Id)
        {
            Qualification qualification = new Qualification();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "GetQualificationById";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QualificationId", Id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                qualification.QualificationId = Convert.ToInt32(reader["Id"]);
                                qualification.QualificationName = reader["QualificationName"].ToString();
                                qualification.Description = reader["Description"].ToString();
                                if (reader["CreatedDate"] != DBNull.Value)
                                    qualification.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                if (reader["ModifiedDate"] != DBNull.Value)
                                    qualification.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return qualification;
            }
        }

        public int UpdateQualification(Qualification qualification)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_UpdateQualification";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@QualificationId", qualification.QualificationId);
                    cmd.Parameters.AddWithValue("@QualificationName", qualification.QualificationName);
                    cmd.Parameters.AddWithValue("@Description", qualification.Description);
                    cmd.Parameters.AddWithValue("@ModifiedDate", qualification.ModifiedDate);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return result;
            }
        }
    }
}
