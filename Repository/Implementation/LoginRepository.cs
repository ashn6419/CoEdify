using DomainModels.Entities;
using DomainModels.ViewModels;
using Microsoft.Extensions.Configuration;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Repository.Implementation
{
    public class LoginRepository : Repository<UserLogin>, ILoginRepository
    {
        public LoginRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public int AddUser(UserLogin userLogin)
        {
            return 0;
        }

        public int DeleteUser(int Id)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_DeleteUserAccount";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", Id);

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

        public UserLoginModel DoLogin(UserLogin user)
        {
            UserLoginModel userLoginModel = new UserLoginModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_DoLogin";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                    cmd.Parameters.AddWithValue("@Password", user.Password);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                userLoginModel.UserLoginId = Convert.ToInt32(reader["UserloginId"]);
                                userLoginModel.UserEmail = reader["UserEmail"].ToString();
                                userLoginModel.Password = reader["Password"].ToString();
                                userLoginModel.Roles[0] = reader["RoleName"].ToString();  // wrete separe method to get roles or use dataset
                                userLoginModel.UserId = Convert.ToInt32(reader["UserId"]);
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
            }
            return userLoginModel;
        }

        public IEnumerable<UserLoginModel> GetAll()
        {
            List<UserLoginModel> userLogins = new List<UserLoginModel>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_GetAllUserLogins";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                UserLoginModel userLogin = new UserLoginModel();
                                userLogin.UserLoginId = Convert.ToInt32(reader["UserloginId"]);
                                userLogin.UserEmail = reader["UserEmail"].ToString();
                                userLogin.Password = reader["Password"].ToString();
                                if (reader["RoleName"] != DBNull.Value)
                                    userLogin.Roles[0] = reader["RoleName"].ToString();
                                if (reader["RoleId"] != DBNull.Value)
                                    userLogin.RoleId = Convert.ToInt32(reader["RoleId"]);
                                userLogins.Add(userLogin);
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
                return userLogins;
            }
        }

        public UserLoginModel GetUserLogin(string Useremail)
        {
            UserLoginModel userLoginModel = new UserLoginModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "GetUserLogin";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserEmail", Useremail);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                userLoginModel.UserLoginId = Convert.ToInt32(reader["UserloginId"]);
                                userLoginModel.UserEmail = reader["UserEmail"].ToString();
                                userLoginModel.Password = reader["Password"].ToString();
                                if (reader["RoleName"] != DBNull.Value)
                                    userLoginModel.Roles[0] = reader["RoleName"].ToString();
                                if (reader["RoleId"] != DBNull.Value)
                                    userLoginModel.RoleId = Convert.ToInt32(reader["RoleId"]);
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
                return userLoginModel;
            }
        }

        public UserLoginModel GetUserLoginById(int Id)
        {
            UserLoginModel userLogin = new UserLoginModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "GetUserLoginById";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserloginId", Id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                userLogin.UserLoginId = Convert.ToInt32(reader["UserloginId"]);
                                userLogin.UserEmail = reader["UserEmail"].ToString();

                                userLogin.Password = reader["Password"].ToString();
                                if (reader["RoleName"] != DBNull.Value)
                                    userLogin.Roles[0] = reader["RoleName"].ToString();
                                if (reader["RoleId"] != DBNull.Value)
                                    userLogin.RoleId = Convert.ToInt32(reader["RoleId"]);
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

                return userLogin;
            }
        }

        public int UpdateUserPassword(UserLogin user)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_updateUserPassword";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@ModifiedDate", user.ModifiedDate);

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
