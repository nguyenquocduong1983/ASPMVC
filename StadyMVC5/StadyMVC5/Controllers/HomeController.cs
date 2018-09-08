using StadyMVC5.Models;
using StadyMVC5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StadyMVC5.Controllers
{
    public class HomeController : Controller
    {
       public ActionResult Index()
        {
            List<SiteUserModel> list = new List<SiteUserModel>();
            using (webgird_dbEntities db = new webgird_dbEntities())
            {
                var model = (
                    from a in db.SiteUsers
                    join b in db.UserRoles on a.RoleID equals b.ID
                    select new SiteUserModel
                    {
                        ID = a.ID,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        DOB = a.DOB,
                        RoleName = b.RoleName
                    }
                    );
                list = model.ToList();
            }
            return View(list);
        }
    }
}