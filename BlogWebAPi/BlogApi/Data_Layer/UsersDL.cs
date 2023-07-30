using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using BlogApi.Models;

namespace BlogApi.Data_Layer
{
    public class UsersDL
         
    {
        string _connectionString = "";
        public UsersDL()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["DemoCN"].ConnectionString;
        }

        public DataTable GetUsers()
        {
            try
            {
                List<User> users = new List<User>();
                DataTable dataTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetUsers", con);
                    command.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                    con.Close();
                }
                return dataTable;
            }
            catch(Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in getting user due to "
                   + exception.Message, exception.InnerException);
            }
        }
        public string AddUser(User user)
        {
            try
            {
                string response = "";
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("CreateUser", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@name", user.Username);
                    command.Parameters.AddWithValue("@password", user.Password);
                    con.Open();
                    command.ExecuteNonQuery();
                    response = "";
                    con.Close();
                }
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in Create user due to "
                   + exception.Message, exception.InnerException);
            }
        }
        public string DeleteUser(int id)
        {
            try
            {
                string response = "";
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("deleteuserbyid", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userid", id);

                    con.Open();
                    command.ExecuteNonQuery();

                    response = "";
                    con.Close();
                }
                return response;
            }
            catch(Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                  + " is encountered in Delete user due to "
                  + exception.Message, exception.InnerException);
            }
        }
    }
            
}