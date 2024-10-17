using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vnr_Intership_Solution.DatabaseContext;

namespace Vnr_Intership_Solution.Controllers
{
    public class CoursesController : Controller
    {
        private readonly CourseDbContext _context;
        public CoursesController(CourseDbContext context) 
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses = await _context.Courses.ToListAsync();
            return View(courses);
        }
    }
}
