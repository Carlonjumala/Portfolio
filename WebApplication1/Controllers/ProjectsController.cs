using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;
using System.Linq;

namespace Portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display a list of all projects
        public IActionResult Index()
        {
            var projects = _context.Projects.ToList(); // Fetch projects from database
            return View(projects);
        }

        // Get: Create Project Form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Post: Add a new project
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }
    }
}
