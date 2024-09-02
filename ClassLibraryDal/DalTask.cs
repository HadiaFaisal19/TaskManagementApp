using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDal
{
    public class DalTask
    {
        public static void AddTask(TaskModel task)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("CreateTask", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaskName", task.TaskName);
                cmd.Parameters.AddWithValue("@TaskDescription", task.TaskDescription);
                cmd.Parameters.AddWithValue("@DueDate", task.DueDate.ToDateTime(TimeOnly.MinValue));
                cmd.Parameters.AddWithValue("@TaskPriority", task.TaskPriority);
                cmd.Parameters.AddWithValue("@SpecialNote", task.SpecialNote);
                cmd.Parameters.AddWithValue("@TaskStatus", task.TaskStatus); 

                cmd.ExecuteNonQuery();
            }
        }


        public static void DeleteTask(int taskId)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DeleteTask", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaskManagmentID", taskId);

                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateTask(TaskModel task)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UpdateTask", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaskManagmentID", task.TaskManagmentID);
                cmd.Parameters.AddWithValue("@TaskName", task.TaskName );
                cmd.Parameters.AddWithValue("@TaskDescription", task.TaskDescription);
                cmd.Parameters.AddWithValue("@DueDate", task.DueDate );
                cmd.Parameters.AddWithValue("@TaskPriority", task.TaskPriority);
                cmd.Parameters.AddWithValue("@SpecialNote", task.SpecialNote);

                cmd.ExecuteNonQuery();
            }
        }

        public static List<TaskModel> GetAllTasks()
        {
            List<TaskModel> tasks = new List<TaskModel>();

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetAllTasks", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TaskModel task = new TaskModel
                    {
                        TaskManagmentID = int.Parse(reader["TaskManagmentID"].ToString()),
                        TaskName = reader["TaskName"].ToString(),
                        TaskDescription = reader["TaskDescription"].ToString(),
                        DueDate = DateOnly.FromDateTime((DateTime)reader["DueDate"]),
                        TaskPriority = reader["TaskPriority"].ToString(),
                        SpecialNote = reader["SpecialNote"].ToString(),
                        TaskStatus = reader["TaskStatus"].ToString()
                    };
                    tasks.Add(task);
                }
            }

            return tasks;
        }


        public static TaskModel GetTaskById(int taskId)
        {
            TaskModel task = null;

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetTaskByID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaskManagmentID", taskId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    task = new TaskModel
                    {
                        TaskManagmentID = int.Parse(reader["TaskManagmentID"].ToString()),
                        TaskName = reader["TaskName"].ToString(),
                        TaskDescription = reader["TaskDescription"].ToString(),
                        DueDate = DateOnly.FromDateTime((DateTime)reader["DueDate"]),
                        TaskPriority = reader["TaskPriority"].ToString(),
                        SpecialNote = reader["SpecialNote"].ToString()
                    };
                }
            }

            return task;
        }
        public static void CompleteTask(int taskId)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("CompleteTask", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaskManagmentID", taskId);
                cmd.Parameters.AddWithValue("@Status", "Completed"); 

                cmd.ExecuteNonQuery();
            }
        }

    }
}
