using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WiseBook.Service.Models;

namespace WiseBook.Service.Controllers
{
    public class CategoryController : ApiController
    {

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetCategoryList()
        {
            var model = DataService.Service.CategoryService
                .SelectByStateForAll()
                .Take(10)
                .Select(x => new CategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsActive = x.IsActive
                }).ToList();

            return Json(model);
        }
    }
}
