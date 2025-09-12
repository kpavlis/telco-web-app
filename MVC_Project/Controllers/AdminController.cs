using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;
using X.PagedList.Extensions;
using MVC_Project.Filters;

namespace MVC_Project.Controllers
{
    [SessionChecker]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly LabDBContext _context;

        public AdminController(ILogger<AdminController> logger, LabDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("FirstName");
            return View();
        }

        public IActionResult Sellers(int? page)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            int PageSize = 10;

            var labDBContext = _context.Sellers.Include(s => s.User);
            return View(labDBContext.ToPagedList( page ?? 1, PageSize));
        }

        public IActionResult CreateSeller()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeller(User user)
        {
            
            try
            {
                user.Property = "Seller";

                _context.Add(user);
                await _context.SaveChangesAsync();

                var seller = new Seller
                {
                    UserId = user.UserId
                };

                _context.Add(seller);
                await _context.SaveChangesAsync();

                return RedirectToAction("Sellers");
            }
            catch (DbUpdateException ex)
            {
                return RedirectToAction("CreateSeller");
            }
        }

        public async Task<IActionResult> DeleteSeller(int? id)
        {
            
            var seller = await _context.Sellers
                .Include(s => s.User)
                .FirstOrDefaultAsync(p => p.SellerId == id);

 
            _context.Users.Remove(seller.User);

            await _context.SaveChangesAsync();

            return RedirectToAction("Sellers");
        }

        public IActionResult Programs( int? page)
        {
            if (page!= null && page < 1){
                page = 1;
            }

            int PageSize = 10;

            return View(_context.Programs.ToPagedList( page ?? 1, PageSize));
        }

        public IActionResult CreateProgram()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgram(Models.Program program)
        {
            try
            {
                _context.Add(program);
                await _context.SaveChangesAsync();
                return RedirectToAction("Programs");
            }
            catch (DbUpdateException ex)
            {
                return RedirectToAction("CreateProgram");
            }
        }

        public async Task<IActionResult> EditProgram(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var program = await _context.Programs.FindAsync(id);

            if (program == null)
            {
                return NotFound();
            }
            return View(program);
        }

        [HttpPost]
        public async Task<IActionResult> EditProgram(Models.Program program)
        {
            try
            {
                _context.Update(program);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramExists(program.ProgramName))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Programs");
        }

        [SkipSessionChecker]
        public IActionResult Signout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        private bool ProgramExists(string id)
        {
            return _context.Programs.Any(e => e.ProgramName == id);
        }
    }
}
