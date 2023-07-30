using System;
using System.Collections.Generic;
using System.Data;
using BlogApi.Data_Layer;
using BlogApi.Models;

namespace BlogApi.Business_Layer
{
    public class UserBL
    {
        public UsersDL dataLayer = new UsersDL();
        public string AddUser(User user)
        {
            try
            {
                string response = dataLayer.AddUser(user);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in adduser due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public List<User> GetUsers()
        {
           
            try
            {
                DataTable table = new DataTable();
                List<User> users = new List<User>();
                table = dataLayer.GetUsers();

                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in table.Rows)
                    {
                        User user = new User();
                        user.UserID = Convert.ToInt32(dataRow["UserId"]);
                        user.Username = dataRow["UserName"].ToString();
                        user.Email = dataRow["UserEmail"].ToString();
                        user.Password = dataRow["Password"].ToString();
                        users.Add(user);
                    }
                }
                return users;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in getting user due to "
                   + exception.Message, exception.InnerException);
            }
        }

        public string DeleteUser(int id)
        {
            try
            {
                string response = dataLayer.DeleteUser(id);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in deleteuser due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}