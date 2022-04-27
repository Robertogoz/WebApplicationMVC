using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplicationMVC.Data;
using WebApplicationMVC.Models;
using WebApplicationMVC.Models.SchoolViewModel;


namespace WebApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDataContext _context;

        public HomeController(ILogger<HomeController> logger, AppDataContext context)
        {
            _logger = logger;
            _context = context;
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

        public async Task<IActionResult> About()
        {
            IQueryable<EnrollmentDateGroup> data =
                from student in _context.Students
                group student by student.EnrollmentDate into DateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = DateGroup.Key,
                    StudentCount = DateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }
    }
}