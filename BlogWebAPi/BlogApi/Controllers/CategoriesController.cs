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
    public class CategoriesController : ApiController
    {
        public CategoriesBL dataLayer = new CategoriesBL();
        [HttpGet]
        [Route("GetCategories")]
        public List<Category> GetCategories()
        {
            try
            {
                List<Category> categories = new List<Category>();
                categories = dataLayer.GetCategories();
                return categories;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in getcategories due to "
                   + exception.Message, exception.InnerException);
            }
        }
        [HttpPost]
        [Route("AddCategory")]
        public string AddCategory([FromBody] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resposne = dataLayer.AddCategory(category);
                    if (!string.IsNullOrEmpty(resposne))
                    {
                        return "Category Added Successfully!";
                    }
                    else
                    {
                        return "Cannot add Successfully!";
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
                   + " is encountered in add category due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}
