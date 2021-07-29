using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using Vidly.Support;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //=======================================//
        public ActionResult New()
        {
            var membershipTypes = _context.membershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                membershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }
        public ActionResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            // return View(customers);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel
                {
                    Customer = customer,
                    membershipTypes = _context.membershipTypes.ToList()
                };
                return View("CustomerForm", viewmodel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                //Alternative: Mapper.Map(custome, customerInDb)
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

                _context.SaveChanges();
            }
            return RedirectToAction(ActionHelpers.Index, ActionHelpers.Customers);
        }
        public ActionResult Details(int? id)
        {
            if (id is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer is null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(customer);
        }
        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                membershipTypes = _context.membershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}