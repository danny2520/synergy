using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;

namespace SynergyDotCom.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactFormModel Form { get; set; } = new ContactFormModel();

        public string Message { get; set; } = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                Message = "Please fill in all fields.";
                return;
            }

            try
            {
                // 1. SETUP THE EMAIL
                var mail = new MailMessage();
                mail.From = new MailAddress("obatayoade@gmail.com"); // Your email
                mail.To.Add("obatayoade@gmail.com"); // Where you want to receive it
                mail.Subject = $"New Synergy Transmission from {Form.Name}";
                mail.Body = $"Name: {Form.Name}\nEmail: {Form.Email}\n\nMessage:\n{Form.Message}";

                // 2. CONFIGURE SMTP (Example for Gmail)
                var smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("obatayoade@gmail.com", "dyoq vgwh bhne ctcn"),
                    EnableSsl = true,
                };

                // 3. SEND
                smtp.Send(mail);
                Message = "Transmission Successful. We will respond shortly.";
            }
            catch (Exception ex)
            {
                Message = "Transmission Failed: " + ex.Message;
            }
        }
    }

    public class ContactFormModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}