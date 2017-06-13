using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ApartmentDomain;
using ApartmentRepositoryClass;
using Apartment.Document;

namespace ApartmentWebsite.Controllers
{
    
    public class ApartmentController : Controller
    {
        // GET: Apartment
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Create_Post(Address address,HttpPostedFileBase photo)
        {
            TryUpdateModel(address);
            if (ModelState.IsValid)
            {
                string id = Session["PersonID"].ToString();
                IApartmentInterface apartmentBusinessLayer = ApartmentRepositoryClass.AddressRepository.IapartmentBusinessLayer();
                apartmentBusinessLayer.RegisterApartmentAddress(address);
                UploadFile uploadFile = new UploadFile();
                var imageName = uploadFile.UploadPersonDoc(photo);
                HelperClass helper = new HelperClass();
                helper.InsertDocument(id, imageName);

                return RedirectToAction("ApartmentList", "Apartment");
            }
            return View();
        }


        [HttpGet]
        public ActionResult EditApartment(int AddressID)
        {
            IApartmentInterface apartmentBusinessLayer = ApartmentRepositoryClass.AddressRepository.IapartmentBusinessLayer();
            Address address = apartmentBusinessLayer.Apartments().Single(m => m.address_ID == AddressID);

            return View(address);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditApartment(Address address)
        {
            if (ModelState.IsValid)
            {
                TryUpdateModel(address);
                IApartmentInterface apartmentBusinessLayer = ApartmentRepositoryClass.AddressRepository.IapartmentBusinessLayer();
                apartmentBusinessLayer.UpdateApartmentAddress(address);
            }
            return View(address);
        }


        public ActionResult DeleteApartment(int apartmentID)
        {
            IApartmentInterface apartmentBusinessLayer = ApartmentRepositoryClass.AddressRepository.IapartmentBusinessLayer();
            apartmentBusinessLayer.DeleteApartment(apartmentID);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        [Authorize(Roles ="Tenant")]
        public ActionResult ApartmentIndex()
        {
            IApartmentInterface apartmentBusinessLayer = ApartmentRepositoryClass.AddressRepository.IapartmentBusinessLayer();
            List<Address> apartments = apartmentBusinessLayer.Apartments().ToList();
            return View(apartments);
        }

        [HttpGet]
        [Authorize(Roles ="Owner")]
        public ActionResult ApartmentList()
        {
            IApartmentInterface apartmentBusinessLayer = ApartmentRepositoryClass.AddressRepository.IapartmentBusinessLayer();
            List<Address> apartments = apartmentBusinessLayer.Apartments().ToList();
            return View(apartments);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Details(int AddressID)
        {
            IApartmentInterface apartmentBusinessLayer = ApartmentRepositoryClass.AddressRepository.IapartmentBusinessLayer();
            Address address = apartmentBusinessLayer.Apartments().Single(m => m.address_ID == AddressID);

            return View(address);
        }

        [HttpGet]
        public ActionResult Download()
        {
            string ID = Session["PersonID"].ToString();
            DownloadFile downloadFile = new DownloadFile();
            HelperClass helper = new HelperClass();
            List<string> nameList = helper.GetDocNameByPersonId(ID);
            downloadFile.DownloadPersonFile(nameList);
            return View();
        }
        [HttpGet]
        [ActionName("RegisterBooking")]
        public ActionResult RegisterBooking_Get(int AddressId)
        {
            IBookingInterface bookingBusinessLayer = ApartmentRepositoryClass.BookingRepository.IbookingBusinessLayer();
            bookingBusinessLayer.BookingDetails(AddressId);
            
            Session["AddressID"] = AddressId;

            return View();
        }
        
        [HttpPost]
        [ActionName("RegisterBooking")]
        [ValidateInput(false)]
        public ActionResult RegisterBooking_Post(FinalRentDetails finalRentDetails)
        {
            Address address = new Address();
            IBookingInterface bookingBusinessLayer = ApartmentRepositoryClass.BookingRepository.IbookingBusinessLayer();
            bookingBusinessLayer.RegisterBooking(finalRentDetails);

            return RedirectToAction("GetFinalRentDetails", "Apartment");
        }

        public ActionResult GetApartmentRent(int AddressID)
        {
            IBookingInterface bookingBusinessLayer = ApartmentRepositoryClass.BookingRepository.IbookingBusinessLayer();
            RentDetails rentDetails = bookingBusinessLayer.GetApartmentRent().Single(m => m.address_ID == AddressID);
            return View(rentDetails);
        }        

        public ActionResult GetFinalRentDetails()
        {
            int AddressID = Convert.ToInt32(Session["AddressID"]);
            IBookingInterface bookingBusinessLayer = ApartmentRepositoryClass.BookingRepository.IbookingBusinessLayer();
            FinalRentDetails finalRentDetails = bookingBusinessLayer.FinalRentDetails().FirstOrDefault(m => m.AddressID == AddressID);

            return View(finalRentDetails);
        }
    }
}