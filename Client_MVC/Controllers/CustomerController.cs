using Client_MVC.Models;
using Client_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Client_MVC.Controllers
{
    public class CustomerController : Controller
    {
        private static readonly List<Customer> _customers = ServiceClient.Customers;

        public IActionResult Index()
        {
            return View(_customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("FirstName, LastName, Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Id = _customers.Any() ? _customers.Max(c => c.Id) + 1 : 1;
                _customers.Add(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public IActionResult Details(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);

            if (customer == null) 
            {
                return NotFound();
            }

            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, FirstName, LastName, Email")] Customer updateCustomer)
        {
            if(id != updateCustomer.Id)
                return NotFound();

            if (ModelState.IsValid) 
            {
                var customer = _customers.FirstOrDefault(c => c.Id == id);

                if (customer == null)
                {
                    return NotFound();
                }
                
                customer.FirstName = updateCustomer.FirstName;
                customer.LastName = updateCustomer.LastName;
                customer.Email = updateCustomer.Email;

                return RedirectToAction(nameof(Index));
            }

            return View(updateCustomer);
        }

        public IActionResult Delete(int id) 
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            _customers.Remove(customer);
            return RedirectToAction(nameof(Index));
        }

    }
}
