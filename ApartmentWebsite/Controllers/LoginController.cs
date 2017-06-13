using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentWebsite.Models;
using System.Web.Security;
using ApartmentDomain;
using ApartmentRepositoryClass;

namespace ApartmentWebsite.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult Index(Login login, string returnUrl)
        {
            IPersonInterface personBusinessLayer = ApartmentRepositoryClass.PersonRepository.IpersonBusinessLayer();
            //try
            //{
                
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(login.UserName, login.Password))
                {
                    Person person = personBusinessLayer.People().Single(m => m.UserName == login.UserName);
                    FormsAuthentication.SetAuthCookie(person.UserName, false);
                    Session["UserName"] = person.UserName;
                    Session["PersonID"] = person.Person_ID;
                    if (person.PersonType == "Owner")
                    {
                        return RedirectToAction("ApartmentList", "Apartment");
                    }
                    else if (person.PersonType == "Tenant")
                    {
                        return RedirectToAction("ApartmentIndex", "Apartment");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View();
                }
            }
            else
            {
                return View(login);
            }

                //if (ModelState.IsValid)
                //{
                //    bool IsValid = personBusinessLayer.AuthenticateUserDetails(login.UserName, login.Password);
                //    if (IsValid)
                //    {
                //        FormsAuthentication.SetAuthCookie(person.UserName, false);
                //        Session["UserName"] = person.UserName;
                //        Session["PersonID"] = person.Person_ID;
                //        if (person.PersonType == "Owner")
                //        {
                //            return RedirectToAction("ApartmentList", "Apartment");
                //        }
                //        else if (person.PersonType == "Tenant")
                //        {
                //            return RedirectToAction("ApartmentIndex", "Apartment");
                //        }
                //    }
                //    else
                //    {

                //    }
                //}
            //}
            //catch
            //{
            //    ModelState.AddModelError("Error", "UserName or Password is incorrect... Please try again!!!");
            //}

            //return View(login);
        }

       
        [ActionName("Create")]
        [HttpGet]
        public ActionResult Create_Get()
        {
            return View("Create");
        }

        
        [ActionName("Create")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create_Post(Person person)
        {
            Person per = new Person();
            TryUpdateModel(person);
            IPersonInterface personBusinessLayer = ApartmentRepositoryClass.PersonRepository.IpersonBusinessLayer();
            bool user = personBusinessLayer.People().Any(x => x.UserName == person.UserName);
            if (!user)
            {
                if (ModelState.IsValid)
                {
                    //IPersonInterface personBusinessLayer = ApartmentRepositoryClass.PersonRepository.IpersonBusinessLayer();
                    per = personBusinessLayer.RegisterPerson(person);
                    personBusinessLayer.InsertPersonRole(person.PersonType, per.Person_ID);

                    Session["UserName"] = person.UserName;
                    Session["PersonID"] = person.Person_ID;
                    if (person.PersonType == "Owner")
                    {
                        return RedirectToAction("ApartmentList", "Apartment");
                    }
                    else if (person.PersonType == "Tenant")
                    {
                        return RedirectToAction("ApartmentIndex", "Apartment");
                    }
                    else if(person.PersonType == "Administrator")
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                }
            }
            else
            {
                ModelState.AddModelError("", "User Name already exist.");
            }
            return View(person);
        }

    }
}