using BankingEx.Models;
using BankingEx.Peristance;
using BankingEx.PeristanceLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingEx.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Username,string password)
        {
            Employee loggedIn = EmployeeContext.Login(Username, password);
            if(loggedIn == null)
            {
                return View();
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult List()
        {
            List<Employee> e = EmployeeContext.GetEmployee();
            return View(e);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee e =EmployeeContext.GetEmployeeById(id);
            return View(e);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee e)//Model binding is happened here
        {
            bool isSuccess = EmployeeContext.Create(e);
            if (isSuccess)
            {
                return RedirectToAction("List");
            }

            return View();
        }


    }
}
