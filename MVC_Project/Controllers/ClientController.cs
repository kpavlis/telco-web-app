using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;
using MVC_Project.ViewModels;
using X.PagedList.Extensions;

namespace MVC_Project.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly LabDBContext _context;

        public ClientController(ILogger<ClientController> logger, LabDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            ViewBag.FirstName = HttpContext.Session.GetString("FirstName");
            return View();
        }

        public async Task<IActionResult> Bills(int? page)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            int PageSize = 10;

            var userId = Int32.Parse(HttpContext.Session.GetString("UserId"));

            var clients = await _context.Clients
                .Where(c => c.UserId == userId)
                .ToListAsync();

            var phoneNumbers = clients.Select(d => d.PhoneNumber).ToList();

            var bills = _context.Bills
                .Include(e => e.PhoneNumberNavigation)
                .Where(e => phoneNumbers.Contains(e.PhoneNumber));

            return View(bills.ToPagedList(page ?? 1, PageSize));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills
                .Include(b => b.PhoneNumberNavigation)
                .FirstOrDefaultAsync(c => c.BillId == id);

            if (bill == null)
            {
                return NotFound();
            }

            var calls = await _context.Calls
                .Where(d => d.BillId == id)
                .ToListAsync();

            var viewModel = new BillDetailsViewModel
            {
                Bill = bill,
                Calls = calls
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Calls(int? page)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            int PageSize = 10;

            var userId = Int32.Parse(HttpContext.Session.GetString("UserId"));

            var clients = await _context.Clients
                .Where(b => b.UserId == userId)
                .ToListAsync();

            var phoneNumbers = clients.Select(c => c.PhoneNumber).ToList();

            var calls = _context.Calls
                .Include(d => d.PhoneNumberNavigation)
                .Where(d => phoneNumbers.Contains(d.PhoneNumber));

            return View(calls.ToPagedList(page ?? 1, PageSize));
           
        }

        public async Task<IActionResult> Bills_Payment(int? page)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            int PageSize = 10;

            var userId = Int32.Parse(HttpContext.Session.GetString("UserId"));

            var clients = await _context.Clients
                .Where(b => b.UserId == userId)
                .ToListAsync();

            var phoneNumbers = clients.Select(c => c.PhoneNumber).ToList();

            var bills = _context.Bills
                .Include(d => d.PhoneNumberNavigation)
                .Where(d => phoneNumbers.Contains(d.PhoneNumber) && d.Payed == false);

            return View(bills.ToPagedList(page ?? 1, PageSize));
        }

        public async Task<IActionResult> Pay_Form(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bills
                .Include(b => b.PhoneNumberNavigation)
                .FirstOrDefaultAsync(m => m.BillId == id);

            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        [HttpPost]
        public async Task<IActionResult> Pay_Procedure(int card_number, string name, int expiration, int cvv_code, int bill)
        {
            var bill_updated = await _context.Bills.FindAsync(bill);

            if (bill_updated == null)
            {
                return NotFound();
            }

            bill_updated.Payed = true;

            _context.Update(bill_updated);

            await _context.SaveChangesAsync();

            return RedirectToAction("Bills_Payment");
        }


        public IActionResult Signout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
