using DomainModels.Entities;
using Microsoft.Extensions.Configuration;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Implementation
{
    public class TaskItemRepository : Repository<TaskItem>, ITaskItemRepository
    {
        public TaskItemRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public IEnumerable<TaskItem> GetAll()
        {
            List<TaskItem> taskItems = new List<TaskItem>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_GetTask_Item";
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                TaskItem taskItem = new TaskItem();
                                taskItem.TaskItemId = Convert.ToInt32(reader["TaskItemId"]);
                                if (reader["TaskId"] != DBNull.Value)
                                    taskItem.TaskId = Convert.ToInt32(reader["TaskId"]);
                                if (reader["Description"] != DBNull.Value)
                                    taskItem.TaskDescription = Convert.ToString(reader["Description"]);
                                if (reader["IsComplete"] != DBNull.Value)
                                    taskItem.IsComplete = Convert.ToBoolean(reader["IsComplete"]);
                                if (reader["CreatedDate"] != DBNull.Value)
                                    taskItem.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                if (reader["ModifiedDate"] != DBNull.Value)
                                    taskItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                                taskItems.Add(taskItem);
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
                return taskItems;
            }
        }

        public IEnumerable<TaskItem> GetAllByTaskId(int TaskId)
        {
            List<TaskItem> taskItems = new List<TaskItem>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_GetTaskItemByTaskId";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaskId", TaskId);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                TaskItem taskItem = new TaskItem();
                                if (reader["TaskItemId"] != DBNull.Value)
                                    taskItem.TaskItemId = Convert.ToInt32(reader["TaskItemId"]);
                                taskItem.TaskItemId = Convert.ToInt32(reader["TaskItemId"]);
                                if (reader["TaskId"] != DBNull.Value)
                                    taskItem.TaskId = Convert.ToInt32(reader["TaskId"]);
                                if (reader["Description"] != DBNull.Value)
                                    taskItem.TaskDescription = Convert.ToString(reader["Description"]);
                                if (reader["IsComplete"] != DBNull.Value)
                                    taskItem.IsComplete = Convert.ToBoolean(reader["IsComplete"]);
                                if (reader["CreatedDate"] != DBNull.Value)
                                    taskItem.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                if (reader["ModifiedDate"] != DBNull.Value)
                                    taskItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);

                                taskItems.Add(taskItem);
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
                return taskItems;
            }
        }

        public TaskItem GetById(int id)
        {
            TaskItem taskItem = new TaskItem();
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_GetTask_ItemDetails";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaskItemId", id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (reader["TaskItemId"] != DBNull.Value)
                                    taskItem.TaskItemId = Convert.ToInt32(reader["TaskItemId"]);
                                if (reader["TaskId"] != DBNull.Value)
                                    taskItem.TaskId = Convert.ToInt32(reader["TaskId"]);
                                if (reader["Description"] != DBNull.Value)
                                    taskItem.TaskDescription = Convert.ToString(reader["Description"]);
                                if (reader["IsComplete"] != DBNull.Value)
                                    taskItem.IsComplete = Convert.ToBoolean(reader["IsComplete"]);
                                if (reader["CreatedDate"] != DBNull.Value)
                                    taskItem.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                if (reader["ModifiedDate"] != DBNull.Value)
                                    taskItem.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
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
                return taskItem;
            }
        }
        public int Add(TaskItem taskItem)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_InsertTask_Item";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TaskId", taskItem.TaskId);
                    cmd.Parameters.AddWithValue("@Description", taskItem.TaskDescription);
                    cmd.Parameters.AddWithValue("@IsComplete", taskItem.IsComplete);
                    cmd.Parameters.AddWithValue("@CreatedDate", taskItem.CreatedDate);
                    cmd.Parameters.AddWithValue("@UserId", taskItem.UserId);
                    cmd.Parameters.AddWithValue("@CreatedByUserId", taskItem.CreatedByUserId);
                    cmd.Parameters.Add("@TaskItemId", SqlDbType.Int);
                    cmd.Parameters["@TaskItemId"].Direction = ParameterDirection.Output;

                    con.Open();
                    result = cmd.ExecuteNonQuery();

                    if (cmd.Parameters["@TaskItemId"].Value != DBNull.Value)
                    {
                        taskItem.TaskItemId = Convert.ToInt32(cmd.Parameters["@TaskItemId"].Value);
                        result = taskItem.TaskItemId;
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
                    cmd.CommandText = "usp_DeleteTask_Item";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaskItemId", id);

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



        public int Update(TaskItem taskItem)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "usp_UpdateTask_Item";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaskItemId", taskItem.TaskItemId);
                    cmd.Parameters.AddWithValue("@TaskId", taskItem.TaskId);
                    cmd.Parameters.AddWithValue("@Description", taskItem.TaskDescription);
                    cmd.Parameters.AddWithValue("@IsComplete", taskItem.IsComplete);
                    cmd.Parameters.AddWithValue("@UserId", taskItem.UserId);
                    cmd.Parameters.AddWithValue("@CreatedByUserId", taskItem.CreatedByUserId);
                    cmd.Parameters.AddWithValue("@ModifiedDate", taskItem.ModifiedDate);

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
