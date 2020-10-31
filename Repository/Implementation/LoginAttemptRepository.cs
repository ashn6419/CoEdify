using DomainModels.Entities;
using Microsoft.Extensions.Configuration;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Repository.Implementation
{
    public class LoginAttemptRepository : Repository<LoginAttempt>, ILoginAttemptRepository
    {
        public LoginAttemptRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public int AddLoginAttempt(LoginAttempt loginAttempt)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "InsertLoginAttempt";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LastLoginTimeStamp", loginAttempt.LastLoginTimeStamp);
                    cmd.Parameters.AddWithValue("@IsSuccess", loginAttempt.IsSuccess);
                    cmd.Parameters.AddWithValue("@UserId", loginAttempt.UserId);
                    cmd.Parameters.AddWithValue("@IP_Addess", loginAttempt.IP_Address);
                    cmd.Parameters.AddWithValue("@CreatedDate", loginAttempt.CreatedDate);
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Direction = ParameterDirection.Output;

                    con.Open();
                    result = cmd.ExecuteNonQuery();

                    if (cmd.Parameters["@Id"].Value != DBNull.Value)
                    {
                        loginAttempt.LoginAttemptId = Convert.ToInt32(cmd.Parameters["Id"].Value);
                        result = loginAttempt.LoginAttemptId;
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

        public int UpdateloginAttempt(LoginAttempt loginAttempt)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_UpdateloginAttempt";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LastLoginTimeStamp", loginAttempt.LastLoginTimeStamp);
                    cmd.Parameters.AddWithValue("@IsSuccess", loginAttempt.IsSuccess);
                    cmd.Parameters.AddWithValue("@UserId", loginAttempt.UserId);
                    cmd.Parameters.AddWithValue("@IP_Addess", loginAttempt.IP_Address);
                    cmd.Parameters.AddWithValue("@ModifiedDate", loginAttempt.ModifiedDate);

                    con.Open();
                    result = cmd.ExecuteNonQuery();

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

        public IEnumerable<LoginAttempt> GetAll()
        {
            List<LoginAttempt> loginHistories = new List<LoginAttempt>();
            using (SqlConnection con = new SqlConnection(dbCon.ConStr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_GetAllloginAttempt";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                LoginAttempt loginAttempt = new LoginAttempt();
                                loginAttempt.LoginAttemptId = Convert.ToInt32(reader["Id"]);
                                loginAttempt.LastLoginTimeStamp = Convert.ToDateTime(reader["LastLoginTimeStamp"]);
                                loginAttempt.UserId = Convert.ToInt32(reader["UserId"]);
                                loginAttempt.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                loginAttempt.IP_Address = Convert.ToString(reader["IP_Addess"]);
                                loginAttempt.IsSuccess = Convert.ToBoolean(reader["IsSuccess"]);
                                loginHistories.Add(loginAttempt);
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
                return loginHistories;
            }
        }

        public LoginAttempt GetLoginHisoryById(int Id)
        {
            LoginAttempt loginAttempt = new LoginAttempt();
            using (SqlConnection con = new SqlConnection(dbCon.ConStr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_GetloginAttemptByUserId";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", Id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                loginAttempt.LoginAttemptId = Convert.ToInt32(reader["Id"]);
                                loginAttempt.LastLoginTimeStamp = Convert.ToDateTime(reader["LastLoginTimeStamp"]);
                                loginAttempt.UserId = Convert.ToInt32(reader["UserLoginId"]);
                                loginAttempt.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                loginAttempt.IP_Address = Convert.ToString(reader["IP_Addess"]);
                                loginAttempt.IsSuccess = Convert.ToBoolean(reader["IsSuccess"]);

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
                return loginAttempt;
            }
        }

        public int Delete(int id)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_DeleteloginAttempt";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

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

    }
}
