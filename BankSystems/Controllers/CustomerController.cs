using BankSystem.Data;
using BankSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }
        // GET: RegisterController
        [HttpPost]
        public IActionResult Index()
        {

            var customer = _context.Customers.ToList();
            return View(customer);


        }
        // GET: RegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterView([FromForm] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var isEmailAlreadyExists = _context.Customers.Any(x => x.CustomerEmail == customer.CustomerEmail);
                if (isEmailAlreadyExists)
                {
                    ModelState.AddModelError("CustomerEmail", "Podany Email już istnieje");

                    return View(customer);
                }
                var customers = new Customer()
                {
                    CustomerName = customer.CustomerName,
                    Adress = customer.Adress,
                    CustomerEmail = customer.CustomerEmail,
                    Password = customer.Password


                };
                _context.Customers.Add(customers);
                _context.SaveChanges();

            }
            return RedirectToAction("LoginView");
        }
        [HttpGet]
        public async Task<IActionResult> RegisterView()
        {

            Customer userView = new Customer();
         

            return View(userView);
        }
        [HttpGet]
        public async Task<IActionResult> LoginView()
        {

            Customer userView = new Customer();
           ;

            return View(userView);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginView([Bind("CustomerEmail,Password")] Customer user)
        {
            var authenticatedUser = _context.Customers.Where(
                u => u.CustomerEmail == user.CustomerEmail &&
                u.Password == user.Password
                ).SingleOrDefault();

            if (authenticatedUser == null)
            {
                ModelState.AddModelError("CustomerEmail","Coś poszło nie tak. Sprawdź e-mail lub hasło");
                ModelState.AddModelError("Password", "Coś poszło nie tak. Sprawdź e-mail lub hasło");
                return View("LoginView");
            }
           

            HttpContext.Session.SetInt32("CustomerID", authenticatedUser.CustomerID);
            HttpContext.Session.SetInt32("role", authenticatedUser.Role);

            return RedirectToAction("Index","Account");
            //return View("Index");
        }



    }
}
