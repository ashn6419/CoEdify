using DomainModels.Entities;
using Microsoft.Extensions.Configuration;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Repository.Implementation
{
    public class LoginHistoryRepository : Repository<LoginHistory>, ILoginHistoryRepository
    {
        public LoginHistoryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public int AddLoginHistory(LoginHistory loginHistory)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_InsertLoginHistory";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LastLoginTimeStamp", loginHistory.LastLoginTimeStamp);
                    cmd.Parameters.AddWithValue("@IsSuccess", loginHistory.IsSuccess);
                    cmd.Parameters.AddWithValue("@UserLoginId", loginHistory.UserLoginId);
                    cmd.Parameters.AddWithValue("@IP_Addess", loginHistory.IP_Address);
                    cmd.Parameters.AddWithValue("@CreatedDate", loginHistory.CreatedDate);
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Direction = ParameterDirection.Output;

                    con.Open();
                    result = cmd.ExecuteNonQuery();

                    if (cmd.Parameters["@Id"].Value != DBNull.Value)
                    {
                        loginHistory.LoginHistoryId = Convert.ToInt32(cmd.Parameters["Id"].Value);
                        result = loginHistory.LoginHistoryId;
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

        public int UpdateLoginHistory(LoginHistory loginHistory)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_UpdateLoginHistory";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LastLoginTimeStamp", loginHistory.LastLoginTimeStamp);
                    cmd.Parameters.AddWithValue("@IsSuccess", loginHistory.IsSuccess);
                    cmd.Parameters.AddWithValue("@UserLoginId", loginHistory.UserLoginId);
                    cmd.Parameters.AddWithValue("@IP_Addess", loginHistory.IP_Address);
                    cmd.Parameters.AddWithValue("@ModifiedDate", loginHistory.ModifiedDate);

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

        public IEnumerable<LoginHistory> GetAll()
        {
            List<LoginHistory> loginHistories = new List<LoginHistory>();
            using (SqlConnection con = new SqlConnection(dbCon.ConStr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_GetAllLoginHistory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                LoginHistory loginHistory = new LoginHistory();
                                loginHistory.LoginHistoryId = Convert.ToInt32(reader["Id"]);
                                loginHistory.LastLoginTimeStamp = Convert.ToDateTime(reader["LastLoginTimeStamp"]);
                                loginHistory.UserLoginId = Convert.ToInt32(reader["UserLoginId"]);
                                loginHistory.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                loginHistory.IP_Address = Convert.ToString(reader["IP_Addess"]);
                                loginHistory.IsSuccess = Convert.ToBoolean(reader["IsSuccess"]);
                                loginHistories.Add(loginHistory);
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

        public LoginHistory GetLoginHisoryById(int Id)
        {
            LoginHistory loginHistory = new LoginHistory();
            using (SqlConnection con = new SqlConnection(dbCon.ConStr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_GetLoginHistoryByUserId";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", Id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                loginHistory.LoginHistoryId = Convert.ToInt32(reader["Id"]);
                                loginHistory.LastLoginTimeStamp = Convert.ToDateTime(reader["LastLoginTimeStamp"]);
                                loginHistory.UserLoginId = Convert.ToInt32(reader["UserLoginId"]);
                                loginHistory.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                loginHistory.IP_Address = Convert.ToString(reader["IP_Addess"]);
                                loginHistory.IsSuccess = Convert.ToBoolean(reader["IsSuccess"]);

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
                return loginHistory;
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
                    cmd.CommandText = "usp_DeleteLoginHistory";
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
