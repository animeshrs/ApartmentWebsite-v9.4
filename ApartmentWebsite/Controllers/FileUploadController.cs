using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ApartmentWebsite.Controllers
{
    public class FileUploadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult UploadProcess()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult UploadProcess(HttpPostedFileBase postedFile)
        {
            if(postedFile != null && postedFile.ContentLength > 0)
            {
                var postedFileName = Path.GetFileName(postedFile.FileName);

                var filePath = Path.Combine(Server.MapPath("~/Content/Documents/"), postedFileName);
                postedFile.SaveAs(filePath);                
            }
            return RedirectToAction("Index", "Home");
        }
    }
}