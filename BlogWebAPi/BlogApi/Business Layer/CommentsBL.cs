using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogApi.Data_Layer;
using BlogApi.Models;

namespace BlogApi.Business_Layer
{
    public class CommentsBL
    {
        public CommentsDL dataLayer = new CommentsDL();

        public string AddComment(Comment comment)
        {
            try
            {
                string response = dataLayer.AddComment(comment);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in addcomment due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}