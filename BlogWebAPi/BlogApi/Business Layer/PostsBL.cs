using System;
using System.Collections.Generic;
using System.Data;
using BlogApi.Data_Layer;
using BlogApi.Models;

namespace BlogApi.Business_Layer
{
    public class PostsBL
    {
        public PostsDL dataLayer = new PostsDL();
        public List<Post> GetPostsWithComments()
        {
            try
            {
                DataTable table = new DataTable();
                List<Post> lstposts = new List<Post>();
                table = dataLayer.GetPostsWithComments();

                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in table.Rows)
                    {
                        Post post = new Post();
                        post.PostID = Convert.ToInt32(dataRow["PostId"]);
                        post.Title = dataRow["Title"].ToString();
                        post.Content = dataRow["Content"].ToString();
                        post.UserName = dataRow["UserName"].ToString();
                        post.Category = dataRow["Category"].ToString();
                        post.UserID = Convert.ToInt32(dataRow["UserID"]);
                        post.Comments = dataRow["Comments"].ToString();
                        lstposts.Add(post);
                    }
                }
                return lstposts;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in getting all posts and comments due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public string AddPost(Post post)
        {
            try
            {
                string response = dataLayer.AddPost(post);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in addpost due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public string UpdatePost(Post post)
        {
            try
            {
                string response = dataLayer.UpdatePost(post);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in updatepost due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public string DeletePost(int id)
        {
            try
            {
                string response = dataLayer.DeletePost(id);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in deletepost due to "
                   + exception.Message, exception.InnerException);
            }
        }

    }
}