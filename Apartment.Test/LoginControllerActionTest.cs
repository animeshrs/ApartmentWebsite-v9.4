using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApartmentWebsite;
using ApartmentWebsite.Models;
using ApartmentWebsite.Controllers;
using Apartment.Security;
using ApartmentDomain;
using ApartmentRepositoryClass;
using Apartment.Document;


namespace Apartment.Test
{
    [TestClass]
    public class LoginControllerActionTest
    {
        [TestMethod]
        public void LoginIndex()
        {
            Login login = new Login();
            login.UserName = "Aadvik";
            login.Password = "asd123";

            //LoginController controller = new LoginController();

            //ViewResult result = controller.Index() as ViewResult;

            //Assert.AreEqual("Hello User! ",login.UserName); 

            if (Membership.ValidateUser(login.UserName, login.Password))
            {
               
            }
        }
        [TestMethod]
        public void RegisterPerson()
        {
            bool y = true;
            Person per = new Person();
            per.UserName = "TestUser";
            per.FirstName = "Test1";
            per.LastName = "L";
            per.Age = 10;
            per.Email = "abc@gmail.com";
            per.Password = "123456";
            per.ConfirmPassword = "123456";
            per.Mobile = "1234567890";
            per.IsMarried = y;
            per.PersonType = "Tenant";

            IPersonInterface personBusinessLayer = ApartmentRepositoryClass.PersonRepository.IpersonBusinessLayer();
            per = personBusinessLayer.RegisterPerson(per);
            personBusinessLayer.InsertPersonRole(per.PersonType, per.Person_ID);

        }
        [TestMethod]
        public void RegisterApartment()
        {
            bool y = true;
            Address address = new Address();
            address.HouseName = "Bc";
            address.FlatNumber = 21;
            address.NumberOfRooms = 2;
            address.DescriptionOfRoom = "Good";
            address.InitialRent = 100;
            address.InitialDeposit = 100;
            address.IsRoomAvailable = y;
            address.OwnerID = 7;
            address.Street = "1st";
            address.City = "Dub";
            address.Country = "Ir";
            address.ZipCode = "2";
            IApartmentInterface apartmentBusinessLayer = ApartmentRepositoryClass.AddressRepository.IapartmentBusinessLayer();
            apartmentBusinessLayer.RegisterApartmentAddress(address);
        }

        [TestMethod]
        public void UpdateApartment()
        {
            bool y = true;
            Address address = new Address();
            address.address_ID = 2;
            address.HouseName = "Bc";
            address.FlatNumber = 21;
            address.NumberOfRooms = 2;
            address.DescriptionOfRoom = "Good";
            address.InitialRent = 100;
            address.InitialDeposit = 100;
            address.IsRoomAvailable = y;
            address.OwnerID = 7;
            address.Street = "1st";
            address.City = "Dub";
            address.Country = "Ir";
            address.ZipCode = "2";
            IApartmentInterface apartmentBusinessLayer = ApartmentRepositoryClass.AddressRepository.IapartmentBusinessLayer();
            apartmentBusinessLayer.UpdateApartmentAddress(address);
        }

        [TestMethod]
        public void BookingDetails()
        {
            int addId = 8;
            IBookingInterface bookingBusinessLayer = ApartmentRepositoryClass.BookingRepository.IbookingBusinessLayer();
            bookingBusinessLayer.BookingDetails(addId);
        }

        [TestMethod]
        public void GetApaRent()
        {
            int addId = 8;
            IBookingInterface bookingBusinessLayer = ApartmentRepositoryClass.BookingRepository.IbookingBusinessLayer();
            RentDetails rentDetails = bookingBusinessLayer.GetApartmentRent().Single(m => m.address_ID == addId);
        }

        [TestMethod]
        public void GetFinalRentDetails()
        {
            int addId = 8;
            IBookingInterface bookingBusinessLayer = ApartmentRepositoryClass.BookingRepository.IbookingBusinessLayer();
            FinalRentDetails finalRentDetails = bookingBusinessLayer.FinalRentDetails().FirstOrDefault(m => m.AddressID == addId);
        }

        [TestMethod]
        public void UploadFile()
        {
            //HttpPostedFileBase photo = new 
            //UploadFile uploadFile = new UploadFile();
            //uploadFile.UploadPersonDoc(photo;
        }

        [TestMethod]
        public void DownloadFile()
        {

        }

        [TestMethod]
        public void GetPersonList()
        {
            IPersonInterface personBusinessLayer = ApartmentRepositoryClass.PersonRepository.IpersonBusinessLayer();
            List<Person> people = personBusinessLayer.People().ToList();
        }

        [TestMethod]
        public void GetApartmentList()
        {
            IApartmentInterface apartmentBusinessLayer = ApartmentRepositoryClass.AddressRepository.IapartmentBusinessLayer();
            List<Address> apartments = apartmentBusinessLayer.Apartments().ToList();
        }
        [TestMethod]
        public void GetApartmentIndex()
        {
            IApartmentInterface apartmentBusinessLayer = ApartmentRepositoryClass.AddressRepository.IapartmentBusinessLayer();
            List<Address> apartments = apartmentBusinessLayer.Apartments().ToList();
        }

    }
}
