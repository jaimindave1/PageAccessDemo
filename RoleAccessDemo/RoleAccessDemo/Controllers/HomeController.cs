using RoleAccessDemo.EntityModel;
using RoleAccessDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleAccessDemo.Controllers
{
    public class HomeController : Controller
    {
        TestEntities db = new TestEntities();
        public ActionResult Index()
        {
            ViewBag.ParentPageList = db.GetParentPages().ToList();

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [HttpPost]
        public ActionResult Index(List<PageAccessViewModel> test)
        {
            foreach (var item in test)
            {
                PageAccess pageAccess = db.PageAccesses.Where(x => x.ID == item.PageAccessID).FirstOrDefault();
                pageAccess.Add = item.Add;
                pageAccess.Edit = item.Edit;
                pageAccess.View = item.View;
                pageAccess.Delete = item.Delete;
                db.SaveChanges();
            }           
            return RedirectToAction("index");
        }

        public ActionResult GetPageAccess(int? ParentPageID)
        {
            var viewModel = new List<PageAccessViewModel>();
            var list = db.GetPageAccessByUser(1, ParentPageID).ToList();
            list.ForEach(x =>
            {
                var item = new PageAccessViewModel();
                item.PageAccessID = x.PageAccessID;
                item.PageName = x.PageName;
                item.isEditVisible = true;
                item.View = (bool)x.View;
                item.Add = (bool)x.Add;
                item.Edit = (bool)x.Edit;
                item.Delete = (bool)x.Delete;
                viewModel.Add(item);
            });
            return PartialView("PageAccess", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
