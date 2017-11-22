using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WiseBook.Admin.UI.Models;
using WiseBook.Admin.UI.Service;

namespace WiseBook.Admin.UI.Controllers
{
    //[Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {

        public ActionResult List()
        {
            var model = DataService.Service.CategoryService
                .SelectByStateForAll()
                .Take(10)
                .Select(x => new CategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsActive=x.IsActive
                }).ToList();

            return View(model);
        }


        [HttpPost]
        public ActionResult Update(CategoryDTO updated)
        {
            DataService.Service.CategoryService
                .Update(new DAL.ORM.Entity.Category
                {
                    Id = updated.Id,
                    Name = updated.Name,
                    Description = updated.Description,
                    IsActive = updated.IsActive
                });

            return Redirect("/category/list");
        }



        public ActionResult GetCategory(int Id)
        {
            var data = DataService.Service.CategoryService.SelectAsTransferable(Id)
                .Select(x => new CategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsActive = x.IsActive
                   
                }).FirstOrDefault();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Insert()
        {
            if (ModelState.IsValid)
            {

                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CategoryDTO data)
        {
            DataService.Service.CategoryService.Insert(
                new DAL.ORM.Entity.Category
                {
                    Name = data.Name,
                    Description = data.Description,
                    IsActive = data.IsActive
                });

            ViewData["success"] = "Category added successfully.";

            return View();
        }

        public ActionResult Delete(int? Id)
        {
            if (Id != null) DataService.Service
                .CategoryService
                .Delete(Id);

            return Redirect("/category/list");
        }


        public ActionResult Deleted()
        {
            var model = DataService.Service
                .CategoryService
                .SelectByState(false, true)
                .Select(x => new CategoryDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList();

            return View(model);
        }

        public ActionResult SuperDelete(int? Id)
        {
            DataService.Service.CategoryService
                .SuperDelete(Id);

            return Redirect("/category/deleted");
        }

        public ActionResult Revert(int? Id)
        {
            DataService.Service.CategoryService
                .Revert(Id);

            return RedirectToAction("Deleted");
        }

    }
}