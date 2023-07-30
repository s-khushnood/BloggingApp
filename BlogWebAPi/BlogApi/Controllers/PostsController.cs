using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlogApi.Business_Layer;
using BlogApi.Models;

namespace BlogApi.Controllers
{
    public class PostsController : ApiController
    {
        public PostsBL dataLayer = new PostsBL();
        [HttpGet]
        [Route("GetPostsWithComments")]
        public List<Post> GetPostsWithComments()
        {
            try
            {
                List<Post> posts = new List<Post>();
                posts= dataLayer.GetPostsWithComments();
                return posts;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetListOfStudents due to "
                   + exception.Message, exception.InnerException);
            }
        }

        [HttpPost]
        [Route("AddPost")]
        public string AddPost([FromBody] Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resposne = dataLayer.AddPost(post);
                    if (!string.IsNullOrEmpty(resposne))
                    {
                        return "Post Done Successfully!";
                    }
                    else
                    {
                        return "Post Not Done Successfully!";
                    }
                }
                else
                {
                    return "Model Is Not Valid";
                }
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in add post due to "
                   + exception.Message, exception.InnerException);
            }
        }

        [HttpPut]
        [Route("UpdatePost")]
        public string UpdatePost([FromBody] Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resposne = dataLayer.UpdatePost(post);
                    if (!string.IsNullOrEmpty(resposne))
                    {
                        return "Post Done Successfully!";
                    }
                    else
                    {
                        return "Post Not Done Successfully!";
                    }
                }
                else
                {
                    return "Model Is Not Valid";
                }
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in update post due to "
                   + exception.Message, exception.InnerException);
            }
        }

        [HttpDelete]
        [Route("DeletePost")]
        public string DeletePost(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resposne = dataLayer.DeletePost(id);
                    if (!string.IsNullOrEmpty(resposne))
                    {
                        return "Post Done Successfully!";
                    }
                    else
                    {
                        return "Post Not Done Successfully!";
                    }
                }
                else
                {
                    return "Model Is Not Valid";
                }
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in add post due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}
