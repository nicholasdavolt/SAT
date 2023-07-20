using Microsoft.AspNetCore.Mvc;
using SAT.UI.MVC.Models;
using MimeKit;
using MailKit.Net.Smtp;
using System.Diagnostics;

namespace SAT.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Contact(ContactViewModel cvm)
        {
            //Checks against validation before processing any data
            if (!ModelState.IsValid)
            {
                
                return View(cvm);
            }

            //Format of email sent by contact form
            string message = $"You have recieved a new email from your site's contact form!<br/>" +
                $"Sender: {cvm.Name}<br/>" +
                $"Email: {cvm.Email}<br/>" +
                $"Subject: {cvm.Subject}<br/>" +
                $"Message: {cvm.Message}";


            var mm = new MimeMessage();


            mm.From.Add(new MailboxAddress("Sender", _config.GetValue<string>("Credentials:Email:User")));

            mm.To.Add(new MailboxAddress("Personal", _config.GetValue<string>("Credentials:Email:Recipient")));

            mm.Subject = cvm.Subject;

            mm.Body = new TextPart("HTML") { Text = message };

            mm.Priority = MessagePriority.Urgent;

            mm.ReplyTo.Add(new MailboxAddress("User",cvm.Email));

            using (var client = new SmtpClient())
            {
                //Connect to the mail server using credentials in appsettings.json

                client.Connect(_config.GetValue<string>("Credentials:Email:Client"));

                //Log in to the mail server using the credentials for our email user
                client.Authenticate(
                    //Username
                    _config.GetValue<string>("Credentials:Email:User"),

                    //Password
                    _config.GetValue<string>("Credentials:Email:Password")

                    );

               

                try
                {
                    //Try to send the email
                    client.Send(mm);
                }
                catch (Exception ex)
                {
                    //If there is an issue, we can store an error message in a ViewBag variable
                    //to be displayed in the View.
                    ViewBag.ErrorMessage = $"There was an error processing your request. Please" +
                        $"try again later.<br/>Error Message: {ex.StackTrace}";

                    //Return the user to the Contact View with their form information intact
                    return View(cvm);
                }

                


            }

            
            return View();
        }



    }
}