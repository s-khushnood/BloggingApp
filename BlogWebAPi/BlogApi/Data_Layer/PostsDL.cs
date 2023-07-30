using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using BlogApi.Models;

namespace BlogApi.Data_Layer
{
    public class PostsDL
    {
        string _connectionString = "";
        public PostsDL()
        {
            _connectionString= WebConfigurationManager.ConnectionStrings["DemoCN"].ConnectionString;
        }
        public DataTable GetPostsWithComments()
        {
            try
            {
                List<Post> LstPosts = new List<Post>();
                DataTable dataTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetPostsWithComments", con);
                    command.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                    con.Close();
                }
                return dataTable;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in getting all posts and comments due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public string UpdatePost(Post post)
        {
            try
            {
                string response = "";
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("UpdatePostById", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", Convert.ToInt32(post.PostID));
                    command.Parameters.AddWithValue("@content", post.Content);
                    command.Parameters.AddWithValue("@title", post.Title);
                    con.Open();
                    response=Convert.ToString(command.ExecuteNonQuery());
                    con.Close();
                }
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in Update Post due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public string AddPost(Post post)
        {
            try
            {
                string response = "";
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("CreatePost", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@title", post.Title);
                    command.Parameters.AddWithValue("@content", post.Content);
                    command.Parameters.AddWithValue("@category", post.Category);
                    command.Parameters.AddWithValue("@userid", Convert.ToInt32(post.UserID));

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
                   + " is encountered in Create Post due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public string DeletePost(int id)
        {
            try
            {
                string response = "";
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("DeletePostById", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PostId", id);

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
                   + " is encountered in Delete Post due to "
                   + exception.Message, exception.InnerException);
            }
        }


    }
}