using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WiseBook.Admin.UI.Models;
using WiseBook.Admin.UI.Service;

namespace WiseBook.Admin.UI.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult List(int page=1, int pageSize=5)
        {
            var model = DataService.Service.UserService
                .SelectByStateForAll()
                .Select(x => new UserDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Lastname = x.Lastname,
                    Email = x.Email,
                    Role = x.Role,
                    IsActive = x.IsActive
                   
                }).ToList();
            PagedList<UserDTO> userModel = new PagedList<UserDTO>(model, page, pageSize);

            return View(userModel);
        }

        public ActionResult Deleted()
        {
            var model = DataService.Service
                .UserService
                .SelectByState(false, true)
                .Select(x => new UserDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Lastname = x.Lastname,
                    Email = x.Email,
                    Role = x.Role,
                    IsActive = x.IsActive
                }).ToList();

            return View(model);
        }

        public ActionResult SuperDelete(int? Id)
        {
            DataService.Service.UserService
                .SuperDelete(Id);

            return Redirect("/user/deleted");
        }

       


    }
}