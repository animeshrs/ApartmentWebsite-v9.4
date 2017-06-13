using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace ApartmentWebsite.Controllers
{                                                                                 
    public class EmailContextController : Controller
    {
        // GET: EmailContext
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult SendEmail()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SendEmail(string receiverEmailId, string subject, string message)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var senderEmailID = new MailAddress("william.animesh@gmail.com");
                    var receiverEmailID = new MailAddress(receiverEmailId, "Receiver");

                    var EmailPassword = "Myprecious12!";
                    var EmailSub = subject;
                    var EmailBody = message;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmailID.Address, EmailPassword)
                    };

                    using (var Message = new MailMessage(senderEmailID, receiverEmailID)
                    {
                        Subject = subject,
                        Body = EmailBody
                    }
                        )
                    {
                        smtp.Send(Message);
                    }

                    return View();
                }
            }
            catch
            {
                ViewBag.Error = "Problems encountered in sending email. Please review the error and try again!!!";
            }
            return View();
        }
    }
}