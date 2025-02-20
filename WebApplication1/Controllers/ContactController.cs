using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.Services;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;

        public ContactController(ApplicationDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactMessage model)
        {
            if (ModelState.IsValid)
            {

                _context.ContactMessages.Add(model);
                await _context.SaveChangesAsync();

                await _emailService.SendEmailAsync(model.Name, model.Email, model.Message);

                ViewData["SuccessMessage"] = "Your message has been sent successfully!";
            }

            return View();
        }
    }
}
