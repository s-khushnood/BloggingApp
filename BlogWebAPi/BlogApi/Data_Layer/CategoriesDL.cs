using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using BlogApi.Models;

namespace BlogApi.Data_Layer
{
    public class CategoriesDL
    {
        string _connectionString = "";
        public CategoriesDL()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["DemoCN"].ConnectionString;
        }
        public DataTable GetCategories()
        {
            try
            {
                List<Category> categories = new List<Category>();
                DataTable dataTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetCategories", con);
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
                   + " is encountered in getting all categories due to "
                   + exception.Message, exception.InnerException);
            }
        }
        public string AddCategory(Category category)
        {
            try
            {
                string response = "";
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("CreateCategory", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", category.CategoryName);
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
                   + " is encountered in Create category due to "
                   + exception.Message, exception.InnerException);
            }

        }
    }
}