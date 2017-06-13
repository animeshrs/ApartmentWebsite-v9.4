using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentDomain;
using ApartmentRepositoryClass;

using System.ComponentModel.DataAnnotations;

namespace ApartmentWebsite.Controllers
{    
    [Authorize(Roles ="Administrator")]
    public class AdminController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            IPersonInterface personBusinessLayer = ApartmentRepositoryClass.PersonRepository.IpersonBusinessLayer();
            List<Person> people = personBusinessLayer.People().ToList();
            return View(people);
        }

        [HttpGet]
        public ActionResult Edit(int PersonID)
        {
            IPersonInterface personBusinessLayer = ApartmentRepositoryClass.PersonRepository.IpersonBusinessLayer();
            Person person = personBusinessLayer.People().Single(m => m.Person_ID == PersonID);
            if (Session["PersonID"] == null)
            {
                Session["PersonID"] = person.Person_ID;
            }
                        
            return View(person);
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Person person)
        {
            ModelState.Remove("Password");
            ModelState.Remove("ConfirmPassword");
            if (ModelState.IsValid)
            {
                TryUpdateModel(person);
                IPersonInterface personBusinessLayer = ApartmentRepositoryClass.PersonRepository.IpersonBusinessLayer();
                personBusinessLayer.UpdatePerson(person);

                return RedirectToAction("Index", "Admin");
            }
            return View(person);
        }

        
        [HttpGet]
        public ActionResult Details(int PersonID)
        {
            IPersonInterface personBusinessLayer = ApartmentRepositoryClass.PersonRepository.IpersonBusinessLayer();
            Person person = personBusinessLayer.People().SingleOrDefault(p => p.Person_ID == PersonID);

            return View(person);
        }

        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Delete(int PersonID)
        {
            IPersonInterface personBusinessLayer = ApartmentRepositoryClass.PersonRepository.IpersonBusinessLayer();
            personBusinessLayer.DeletePerson(PersonID);

            return RedirectToAction("Index", "Admin");
        }

        
        [HttpGet]
        public ActionResult ApartmentIndex()
        {
            IApartmentInterface apartmentBusinessLayer = ApartmentRepositoryClass.AddressRepository.IapartmentBusinessLayer();
            List<Address> apartments = apartmentBusinessLayer.Apartments().ToList();
            return View(apartments);
        }     


        //public ActionResult GetBookingDetails(int AddressId)
        //{
        //    IBookingInterface bookingBusinessLayer = ApartmentRepositoryClass.BookingRepository.IbookingBusinessLayer();
        //    List<BookingDetails> bookingDetails = bookingBusinessLayer.BookingDetails(AddressId);
        //    return View(bookingDetails);
        //}
    }
}
