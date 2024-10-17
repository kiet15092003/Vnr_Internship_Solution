using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vnr_Intership_Solution.DatabaseContext;
using System.Linq;

namespace Vnr_Intership_Solution.Controllers
{
    public class SubjectController : Controller
    {
        private readonly CourseDbContext _context;

        public SubjectController(CourseDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int courseId)
        {
            var subjects = _context.Subjects
                .Where(s => s.CourseId == courseId)
                .ToList();

            return View(subjects);
        }
    }
}
