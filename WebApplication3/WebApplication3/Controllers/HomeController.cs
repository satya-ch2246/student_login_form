using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        Employee obj = new Employee();
        public IActionResult Index()
        {
           var response=obj.GetAllEmployes();  
            return View(response);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                Employee emp=new Employee();
                emp.AddEmployee(obj);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            var response=obj.GetAllEmployes().Single(a=>a.Id==id);
            return View(response);
        }
        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee();
                emp.EditEmployee(obj);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var response = obj.GetAllEmployes().Single(a => a.Id == id);
            return View(response);
        }
        [HttpPost]
        public IActionResult Delete(Employee obj)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee();
                emp.DeleteEmployee(obj.Id);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        public IActionResult Details(int id)
        {
            var response = obj.GetAllEmployes().Single(a => a.Id == id);
            return View(response);
        }
    }
}
