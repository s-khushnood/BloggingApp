using System;
using System.Collections.Generic;
using System.Data;
using BlogApi.Data_Layer;
using BlogApi.Models;

namespace BlogApi.Business_Layer
{
    public class CategoriesBL
    {
        public CategoriesDL dataLayer = new CategoriesDL();
        public List<Category> GetCategories()
        {
            try
            {
                DataTable table = new DataTable();
                List<Category> categories = new List<Category>();
                table = dataLayer.GetCategories();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in table.Rows)
                    {
                        Category category = new Category();
                        category.CategoryID = Convert.ToInt32(dataRow["catId"]);
                        category.CategoryName = dataRow["CatName"].ToString();
                        categories.Add(category);
                    }
                }
                return categories;
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
                string response = dataLayer.AddCategory(category);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in addcategory due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}