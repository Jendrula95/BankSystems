using BankSystem.Data;
using BankSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Controllers
{
    public class AccountController : Controller
    {

        private readonly AppDbContext _context;
        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        // GET: LogedController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("CustomerID") == null)
            {
                return RedirectToAction("LoginView","Customer");
            }
            var accounts = from m in _context.Accounts
                           select m;
            if (HttpContext.Session.GetInt32("role") == 1)
            {
                accounts = accounts.Where(m => m.CustomerID == HttpContext.Session.GetInt32("CustomerID"));
            }
            var account = accounts.ToList();
            return View(account);
        }

        [HttpGet]
        public async Task<IActionResult> AddAccount()
        {


            Account viewModel = new Account();
           

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddAccount([FromForm] Account viewModel)
        {
            if (ModelState.IsValid)
            {
                var account = new Account()
                {
                    AccountNumber = viewModel.AccountNumber,
                    CurrencyID = viewModel.CurrencyID,
                    CustomerID = viewModel.CustomerID,
                };
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

        // GET: konrtolerTestowy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Currency)
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: konrtolerTestowy/Create
        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("CustomerID") == null)
            {
                return View("Index", "Home");
            }
            ViewData["CurrencyID"] = new SelectList(_context.Currencies, "CurrencyID", "CurrencyName");
            return View();
        }

        // POST: konrtolerTestowy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAction(string Name, int AccountNumber, int CurrencyID, int CustomerID)
        {
            if (HttpContext.Session.GetInt32("CustomerID") == null)
            {
                ViewBag.error = ("Hasło musi posiadać przynajmniej jedną dużą literę i cyfrę");
                return View("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                var account = new Account { Name = Name, AccountNumber = AccountNumber, CurrencyID = CurrencyID, CustomerID = CustomerID, Value = (decimal)0.00 };
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }

}
