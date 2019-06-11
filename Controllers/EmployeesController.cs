using CosmosDBExample1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CosmosDBExample1.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public async Task<ActionResult> Index()
        {
            return View(await DocumentDBRepository<Employee>.GetItemsAsync(emp => true));
        }
        // GET: Employees/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await DocumentDBRepository<Employee>.GetItemAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Department,IsPermanent")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Employee>.CreateItemAsync(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await DocumentDBRepository<Employee>.GetItemAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
            // POST: Employees/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Department,IsPermanent")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Employee>.UpdateItemAsync(employee.Id, employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await DocumentDBRepository<Employee>.GetItemAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await DocumentDBRepository<Employee>.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}

