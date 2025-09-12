using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;
using MVC_Project.ViewModels;
using X.PagedList.Extensions;
using MVC_Project.Filters;

namespace MVC_Project.Controllers
{

    [SessionChecker]
    public class SellerController : Controller
    {
        private readonly ILogger<SellerController> _logger;
        private readonly LabDBContext _context;

        public SellerController(ILogger<SellerController> logger, LabDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("FirstName");
            return View();
        }

        public IActionResult Clients(int? page)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            int PageSize = 10;

            var labDBContext = _context.Clients.Include(c => c.PhoneNumberNavigation).Include(c => c.User);

            return View(labDBContext.ToPagedList(page ?? 1, PageSize));
        }

        public IActionResult CreateClient()
        {
            ViewBag.ProgramNames = new SelectList(_context.Programs, "ProgramName", "ProgramName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientViewModel createClientViewModel)
        {

            try { 
                _context.Add(createClientViewModel.User);
                await _context.SaveChangesAsync();


                _context.Add(createClientViewModel.Phone);
                await _context.SaveChangesAsync();

                createClientViewModel.Client.UserId = createClientViewModel.User.UserId;
                createClientViewModel.Client.PhoneNumber = createClientViewModel.Phone.PhoneNumber;
           

                _context.Add(createClientViewModel.Client);
                await _context.SaveChangesAsync();

                return RedirectToAction("Clients");
            }
            catch (DbUpdateException ex)
            {
                return RedirectToAction("CreateClient");
            }
        }

        public IActionResult Phones(int? page)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            int PageSize = 10;

            var labDBContext = _context.Clients.Include(c => c.PhoneNumberNavigation).Include(c => c.User);

            return View(labDBContext.ToPagedList(page ?? 1, PageSize));
        }

        public async Task<IActionResult> EditPhone(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var program = await _context.Phones.FindAsync(id);

            if (program == null)
            {
                return NotFound();
            }

            ViewBag.ProgramNames = new SelectList(_context.Programs, "ProgramName", "ProgramName");
            return View(program);
        }

        [HttpPost]
        public async Task<IActionResult> EditPhone(Phone phone)
        {
            try
            {
                _context.Update(phone);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(phone.PhoneNumber))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("Phones");
        }

        public IActionResult Bills(int? page)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            int PageSize = 10;

            var labDBContext = _context.Bills;

            return View(labDBContext.ToPagedList(page ?? 1, PageSize));
        }

        public IActionResult CreateBill()
        {
            ViewData["PhoneNumber"] = new SelectList(_context.Phones, "PhoneNumber", "PhoneNumber");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBill(Bill bill)
        {
            try
            {
                _context.Add(bill);
                await _context.SaveChangesAsync();
                return RedirectToAction("Bills");
            }
            catch (DbUpdateException ex)
            {
                return RedirectToAction("CreateBill");
            }
        }

        public IActionResult ClientCalls(string phonenumber, int? page)
        {
            if (page != null && page < 1)
            {
                page = 1;
            }

            int PageSize = 10;

            var calls = _context.Calls
                .Where(b => b.PhoneNumber == phonenumber) ;

            ViewBag.PhoneNumber = phonenumber;

            return View(calls.ToPagedList(page ?? 1, PageSize));

        }

        [SkipSessionChecker]
        public IActionResult Signout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        private bool PhoneExists(string id)
        {
            return _context.Phones.Any(e => e.PhoneNumber == id);
        }
    }
}
