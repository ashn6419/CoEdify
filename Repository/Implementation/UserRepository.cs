using ApplicationCore;
using DomainModels.Entities;
using DomainModels.ViewModels;
using Microsoft.Extensions.Configuration;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;

namespace Repository.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly string constr = string.Empty;
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
            constr = dbCon.GetConnection();
        }

        public User AddUser(UserLogin user)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_InsertUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    cmd.Parameters.AddWithValue("@Date_Of_Birth", user.Date_Of_Birth);
                    cmd.Parameters.AddWithValue("@Address", user.Address);
                    cmd.Parameters.AddWithValue("@ContactNo", user.ContactNo);
                    cmd.Parameters.AddWithValue("@QualificationId", user.QualificationId);
                    cmd.Parameters.AddWithValue("@CreatedDate", user.CreateDate);
                    cmd.Parameters.AddWithValue("@City", user.CityId);
                    cmd.Parameters.AddWithValue("@State", user.StateId);
                    cmd.Parameters.AddWithValue("@CreatedByUserId", user.CreatedByUserId);
                    cmd.Parameters.Add("@UserLoginId", SqlDbType.Int);
                    cmd.Parameters["@UserLoginId"].Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("@userId", SqlDbType.Int);
                    cmd.Parameters["@userId"].Direction = ParameterDirection.Output;

                    result = cmd.ExecuteNonQuery();
                    if (cmd.Parameters["@UserLoginId"].Value != DBNull.Value)
                        user.UserLoginId = Convert.ToInt32(cmd.Parameters["@UserLoginId"].Value);
                    if (cmd.Parameters["@userId"].Value != DBNull.Value)
                        user.UserId = Convert.ToInt32(cmd.Parameters["@userId"].Value);
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return user;
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
                    cmd.CommandText = "DeleteUser";
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

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_GetAllUsers";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                User user = new User();
                                user.UserId = Convert.ToInt32(reader["UserRegistrationId"]);
                                user.UserName = reader["UserName"].ToString();
                                user.Address = reader["Address"].ToString();
                                user.Date_Of_Birth = Convert.ToDateTime(reader["Date_Of_Birth"]);
                                user.ContactNo = Convert.ToInt32(reader["ContactNo"]);
                                user.QualificationId = Convert.ToInt32(reader["QualificationId"]);
                                user.CreateDate = Convert.ToDateTime(reader["CreatedDate"]);
                                user.ModificationDate = Convert.ToDateTime(reader["ModifiedDate"]);
                                user.Email = reader["Email"].ToString();
                                user.Gender = reader["Gender"].ToString();
                                user.CityId = Convert.ToInt32(reader["CityId"]);
                                user.StateId = Convert.ToInt32(reader["StateId"]);
                                user.CreatedByUserId = Convert.ToInt32(reader["CreatedByUserId"]);

                                users.Add(user);
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
                return users;
            }
        }

        public User GetUserById(int Id)
        {
            User user = new User();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_GetUserById";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", Id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                user.UserId = Convert.ToInt32(reader["UserId"]);
                                user.UserName = reader["UserName"].ToString();
                                user.Address = reader["Description"].ToString();
                                user.Date_Of_Birth = Convert.ToDateTime(reader["Date_Of_Birth"]);
                                user.ContactNo = Convert.ToInt32(reader["ContactNo"]);
                                user.QualificationId = Convert.ToInt32(reader["QualificationId"]);
                                user.Email = reader["Email"].ToString();
                                user.Gender = reader["Gender"].ToString();
                                user.CreateDate = Convert.ToDateTime(reader["CreatedDate"]);
                                user.ModificationDate = Convert.ToDateTime(reader["ModifiedDate"]);
                                user.CreatedByUserId = Convert.ToInt32(reader["CreatedByUserId"]);
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
                return user;
            }
        }

        public int UpdateUser(UserLogin user, int UserQualificationId)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_UpdateUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", user.UserId);
                    cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    cmd.Parameters.AddWithValue("@Date_Of_Birth", user.Date_Of_Birth);
                    cmd.Parameters.AddWithValue("@Address", user.Address);
                    cmd.Parameters.AddWithValue("@ContactNo", user.ContactNo);
                    cmd.Parameters.AddWithValue("@QualificationId", user.QualificationId);
                    cmd.Parameters.AddWithValue("@ModifiedDate", user.ModificationDate);
                    cmd.Parameters.AddWithValue("@City", user.CityId);
                    cmd.Parameters.AddWithValue("@State", user.StateId);
                    cmd.Parameters.AddWithValue("@CreatedByUserId", user.CreatedByUserId);
                    cmd.Parameters.AddWithValue("@UserQualificationId", UserQualificationId);

                    result = cmd.ExecuteNonQuery();

                }

                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return result;
        }

        public PagingModel<User> GetAllUsers(int page, int pageSize, string sort, string sortDir)
        {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_GetAllUsers";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                User user = new User();
                                if (reader["UserId"] != DBNull.Value)
                                    user.UserId = Convert.ToInt32(reader["UserId"]);
                                if (reader["UserName"] != DBNull.Value)
                                    user.UserName = reader["UserName"].ToString();
                                if (reader["Address"] != DBNull.Value)
                                    user.Address = reader["Address"].ToString();
                                if (reader["Date_Of_Birth"] != DBNull.Value)
                                    user.Date_Of_Birth = Convert.ToDateTime(reader["Date_Of_Birth"]);
                                if (reader["Email"] != DBNull.Value)
                                    user.Email = reader["Email"].ToString();
                                if (reader["Gender"] != DBNull.Value)
                                    user.Gender = reader["Gender"].ToString();
                                if (reader["ContactNo"] != DBNull.Value)
                                    user.ContactNo = Convert.ToInt32(reader["ContactNo"]);
                                if (reader["QualificationId"] != DBNull.Value)
                                    user.QualificationId = Convert.ToInt32(reader["QualificationId"]);
                                if (reader["CreatedDate"] != DBNull.Value)
                                    user.CreateDate = Convert.ToDateTime(reader["CreatedDate"]);
                                if (reader["ModifiedDate"] != DBNull.Value)
                                    user.ModificationDate = Convert.ToDateTime(reader["ModifiedDate"]);
                                if (reader["CreatedByUserId"] != DBNull.Value)
                                    user.CreatedByUserId = Convert.ToInt32(reader["CreatedByUserId"]);
                                users.Add(user);
                            }
                        }
                    }
                    // users;
                    IQueryable<User> data = (IQueryable<User>)users;

                    sortDir = sortDir.ToLower();
                    switch (sort.ToLower())
                    {
                        case "username":
                            data = sortDir == "asc" ? data.OrderBy(a => a.UserName) : data.OrderByDescending(u => u.UserName);
                            break;
                        case "contactno":
                            data = sortDir == "asc" ? data.OrderBy(a => a.ContactNo) : data.OrderByDescending(u => u.ContactNo);
                            break;
                        default:
                            data = sortDir == "asc" ? data.OrderBy(a => a.UserId) : data.OrderByDescending(u => u.UserId);
                            break;
                    }

                    int count = data.Count();                                       // suppose 100 records
                    data = data.Skip((page - 1) * pageSize).Take(pageSize);    // returns no. of records per pages     data.skip(0).take(10)  
                                                                               // if pageno is 1 and pagesize is 10

                    PagingModel<User> model = new PagingModel<User>
                    {
                        DataSource = data,
                        PageSize = pageSize,
                        TotalRows = count
                    };
                    return model;
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
        }

    }
}

