using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using BlogApi.Models;

namespace BlogApi.Data_Layer
{
    public class CommentsDL
    {
        string _connectionString = "";
        public CommentsDL()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["DemoCN"].ConnectionString;
        }

        public string AddComment(Comment comment)
        {
            try
            {
                string response = "";
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("CreateComment", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@comment", comment.CommentText);
                    command.Parameters.AddWithValue("@userid", Convert.ToInt32(comment.UserID));
                    command.Parameters.AddWithValue("@postid", Convert.ToInt32(comment.PostID));
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
                   + " is encountered in Create comment due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public string DeleteComment(Comment comment)
        {
            try
            {
                string response = "";
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("DeleteCommentbyId", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@commentid", Convert.ToInt32(comment.CommentID));

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
                   + " is encountered in delete comment due to "
                   + exception.Message, exception.InnerException);
            }
        }

    }
}