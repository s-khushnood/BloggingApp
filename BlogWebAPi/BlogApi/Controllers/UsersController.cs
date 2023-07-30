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
    public class UsersController : ApiController
    {
        public UserBL dataLayer = new UserBL();
        [HttpPost]
        [Route("AddUser")]
        public string AddUser([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resposne = dataLayer.AddUser(user);
                    if (!string.IsNullOrEmpty(resposne))
                    {
                        return "Account Created Successfully!";
                    }
                    else
                    {
                        return "Cannot Create Account!";
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
                   + " is encountered in add user due to "
                   + exception.Message, exception.InnerException);
            }
        }

        [HttpGet]
        [Route("GetUsers")]
        public List<User> GetUsers()
        {
            try
            {
                List<User> users = new List<User>();
                users = dataLayer.GetUsers();
                return users;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in Getuserbyemail due to "
                   + exception.Message, exception.InnerException);
            }
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public string DeleteUser(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resposne = dataLayer.DeleteUser(id);
                    if (!string.IsNullOrEmpty(resposne))
                    {
                        return "Your Account Delete Successfully!";
                    }
                    else
                    {
                        return "Can't delete!";
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
                   + " is encountered in delete user due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}
