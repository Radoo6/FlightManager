using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlightManagerData;
using FlightManagerData.Models;
using FlightManager.Utilities;
using System.Text;

namespace FlightManager.Controllers
{
    public class CustomersController : Controller
    {
        private readonly FlightContext _context;

        public CustomersController(FlightContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            byte[] buffer = new byte[100];
            if (HttpContext.Session.TryGetValue("username", out buffer))
            {
                buffer = null;
                return View(await _context.Customers.ToListAsync());
            }
            return RedirectToAction("Login", "Customers");
        }

        public async Task<IActionResult> Login()
        {
            ViewData["result"] = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (username == null || password == null)
            {
                ViewData["result"] = "Type your username and password first!";
                return View();
            }
            string hashedPassword = PasswordSecurity.ComputeSha256Hash(password);
            var customer = await _context.Customers
               .FirstOrDefaultAsync(m => m.Username == username && m.Password == hashedPassword);
            if (customer == null)
            {
                ViewData["result"] = "Invalid username or password!";
                return View();
            }
            HttpContext.Session.Set("username", Encoding.UTF8.GetBytes(customer.Username));
            HttpContext.Items.Add("customerId", customer.CustomerId);
            TempData["customerId"] = customer.CustomerId;
            if (customer.IsAdmin)
            {
                HttpContext.Items.Add("isAdmin", 1);
                TempData["isAdmin"] = 1;
            }
            else
            {
                HttpContext.Items.Add("isAdmin", 0);
                TempData["isAdmin"] = 0;
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            TempData["isAdmin"] = 0;
            TempData["customerId"] = null;
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            
                return View(customer);
           
            
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,Username,Password,ConfirmPassword,Mail,FirstName,LastName,Egn,Adress,TelephoneNumber,IsAdmin")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                ViewData["result"] = "";
                ViewData["egn"] = "";
                if (customer.Egn.Length!=10)
                {
                    ViewData["egn"] = "Not valid!";
                    return View();
                }
                if (customer.Password!=customer.ConfirmPassword)
                {
                    ViewData["result"] = "Password don't match!";
                    return View();
                }
                if (!CheckEgn(customer.Egn))
                {
                    ViewData["egn"] = "Not valid!";
                    return View();
                }
                customer.Password = PasswordSecurity.ComputeSha256Hash(customer.Password);
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,Username,Password,Mail,FirstName,LastName,Egn,Adress,TelephoneNumber,IsAdmin")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
        private static bool CheckEgn(string egn)
        {
            int b = (egn[0] - '0') * 2 + (egn[1] - '0') * 4 + (egn[2] - '0') * 8 + (egn[3] - '0') * 5 + (egn[4] - '0') * 10 + (egn[5] - '0') * 9 + (egn[6] - '0') * 7 + (egn[7] - '0') * 3 + (egn[8] - '0') * 6;
            int q = b / 11;
            q = b - q * 11;
            if (q == egn[9] - '0')
                return true;
            return false;
        }
    }
}
