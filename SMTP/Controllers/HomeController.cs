using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Reflection;


namespace SMTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult SendMail(string mail)
        {
            using (MailMessage mm = new MailMessage("hm2417871@gmail.com", mail))
            {
                mm.Subject = "Test mail service";
                mm.Body = "<h1>Hii My Name is Harshit Mishra</h1>";
                mm.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("hm2417871@gmail.com", "cuzegnmfhpaajwag");
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    return Ok("mail sent");
                }
            }
        }

    }
}

//Flow Explanation:

//When the SendMail function is called with an email address (mail), it creates a
//MailMessage with the sender and recipient information, subject, body, and HTML flag.
//It then sets up a SmtpClient configured for Gmail SMTP, including SSL encryption and authentication
//using the provided credentials.
//Finally, it sends the email (mm) using the SmtpClient (smtp.Send(mm)), and upon successful sending,
//it returns an HTTP response indicating success.
//This function effectively encapsulates the process of creating and sending an email via Gmail's SMTP server using C#.
