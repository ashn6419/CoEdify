using DomainModels.Entities;
using Microsoft.Extensions.Configuration;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

namespace Repository.Implementation
{
    public class TaskRepository : Repository<Tasks>, ITaskRepository
    {
        public TaskRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public int Add(Tasks task)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_InsertTask";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Description", task.Description);
                    cmd.Parameters.AddWithValue("@due_date", task.Due_date);
                    cmd.Parameters.AddWithValue("@IsComplete", task.IsComplete);
                    cmd.Parameters.AddWithValue("@CreatedDate", task.CreatedDate);
                    cmd.Parameters.AddWithValue("@UserId", task.UserId);
                    cmd.Parameters.AddWithValue("@TaskTypeId", task.TaskTypeId);
                    cmd.Parameters.AddWithValue("@CreatedByUserId", task.CreatedByUserId);
                    cmd.Parameters.Add("@TaskId", SqlDbType.Int);
                    cmd.Parameters["@TaskId"].Direction = ParameterDirection.Output;

                    con.Open();
                    result = cmd.ExecuteNonQuery();

                    if (cmd.Parameters["@TaskId"].Value != DBNull.Value)
                    {
                        task.TaskId = Convert.ToInt32(cmd.Parameters["@TaskId"].Value);
                        result = task.TaskId;
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

        public int Delete(int id)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_DeleteTask";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaskId", id);

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

        public IEnumerable<Tasks> GetAll()
        {
            List<Tasks> tasks = new List<Tasks>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_GetTask";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Tasks task = new Tasks();
                                if (reader["TaskId"] != DBNull.Value)
                                    task.TaskId = Convert.ToInt32(reader["TaskId"]);
                                if (reader["Description"] != DBNull.Value)
                                    task.Description = reader["Description"].ToString();
                                if (reader["due_date"] != DBNull.Value)
                                    task.Due_date = Convert.ToDateTime(reader["due_date"]);
                                if (reader["IsComplete"] != DBNull.Value)
                                    task.IsComplete = Convert.ToBoolean(reader["IsComplete"]);
                                if (reader["CreatedDate"] != DBNull.Value)
                                    task.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                if (reader["ModifiedDate"] != DBNull.Value)
                                    task.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                                if (reader["UserId"] != DBNull.Value)
                                    task.UserId = Convert.ToInt32(reader["UserId"]);
                                if (reader["CreatedByUserId"] != DBNull.Value)
                                    task.CreatedByUserId = Convert.ToInt32(reader["CreatedByUserId"]);

                                tasks.Add(task);
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
                return tasks;
            }
        }

        public Tasks GetById(int id)
        {
            Tasks task = new Tasks();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_GetTaskDetails";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaskId", id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (reader["TaskId"] != DBNull.Value)
                                    task.TaskId = Convert.ToInt32(reader["TaskId"]);
                                if (reader["Description"] != DBNull.Value)
                                    task.Description = reader["Description"].ToString();
                                if (reader["due_date"] != DBNull.Value)
                                    task.Due_date = Convert.ToDateTime(reader["due_date"]);
                                if (reader["IsComplete"] != DBNull.Value)
                                    task.IsComplete = Convert.ToBoolean(reader["IsComplete"]);
                                if (reader["CreatedDate"] != DBNull.Value)
                                    task.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                if (reader["ModifiedDate"] != DBNull.Value)
                                    task.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                                if (reader["IsActive"] != DBNull.Value)
                                    task.IsActive = Convert.ToBoolean(reader["IsActive"]);
                                if (reader["UserId"] != DBNull.Value)
                                    task.UserId = Convert.ToInt32(reader["UserId"]);
                                if (reader["CreatedByUserId"] != DBNull.Value)
                                    task.CreatedByUserId = Convert.ToInt32(reader["CreatedByUserId"]);
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
                return task;
            }
        }

        public int Update(Tasks task)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_UpdateTask";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TaskId", task.TaskId);
                    cmd.Parameters.AddWithValue("@Description", task.Description);
                    cmd.Parameters.AddWithValue("@due_date", task.Due_date);
                    cmd.Parameters.AddWithValue("@IsComplete", task.IsComplete);
                    cmd.Parameters.AddWithValue("@ModifiedDate", task.ModifiedDate);
                    cmd.Parameters.AddWithValue("@UserId", task.UserId);
                    cmd.Parameters.AddWithValue("@CreatedByUserId", task.CreatedByUserId);

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
    }
}
