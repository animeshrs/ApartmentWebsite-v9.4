using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ApartmentRepositoryClass;
using ApartmentDomain;

namespace ApartmentWebsite.Controllers
{    
    public class HomeController : Controller
    {
        
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Index_Get()
        {
            return RedirectToAction("Index", "Home");
        }

        
        [HttpPost]
        [ActionName("Index")]
        [ValidateInput(false)]
        public ActionResult Index_Post()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            
            return RedirectToAction("Index", "Login");            
        }
    }
}