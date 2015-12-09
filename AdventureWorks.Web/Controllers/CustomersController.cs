using AdventureWorks.DomainModel;
using AdventureWorks.DomainPersistence.DocumentDb;
using AdventureWorks.ViewModel;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Web.Controllers
{
    public class CustomersController : Controller
    {
        private Repository<Customer> _repository = new Repository<Customer>();

        public async Task<ActionResult> Index()
        {
            var items = 
                _repository
                .GetItems(xx => true)
                //.Take(10)
                .ToList();
            return View(items);
        }

        public async Task<ActionResult> Page(int pageSize = 10, string continuation = "")
        {
            var page = await _repository.GetPageAsync(xx => true, pageSize, continuation);
            return View(page);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var i = _repository.GetItem(xx => xx.id == id);
            return View(i);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var i = _repository.GetItem(xx => xx.id == id);
            return View(i);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, Customer source)
        {
            var target = _repository.GetItem(xx => xx.id == id);

            target.LastName = source.LastName;
            target.FirstName = source.FirstName;

            await _repository.UpdateItemAsync(xx => xx.Id == id.ToString(), target);

            return RedirectToAction("Page");
        }

        public async Task<ActionResult> SubTotals(int customerID, int pageSize = 10, string continuation = "")
        {
            var page = await _repository.QueryItemsAsync<SubTotals>("SELECT c.CustomerID, s.SubTotal FROM c JOIN s IN c.SalesOrderHeader WHERE c.CustomerID = @customerID", new { customerID = customerID });
            return View(page);
        }
    }
}