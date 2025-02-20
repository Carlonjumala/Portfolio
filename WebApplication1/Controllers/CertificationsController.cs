using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class CertificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display a list of all certifications
        public IActionResult Index()
        {
            var certifications = _context.Certifications.ToList();
            return View(certifications);
        }

        // Add a new certification
        [HttpPost]
        public IActionResult AddCertification(Certification certification)
        {
            if (ModelState.IsValid)
            {
                _context.Certifications.Add(certification);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirect to list of certifications
            }
            return View(certification); // Return to the form if validation fails
        }
    }
}
