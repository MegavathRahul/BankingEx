using BankingEx.EFModels;
using System.Collections.Generic;
using BankingEx.EFPeristanceLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using BankingEx.EFPersistenceLayer;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace BankingEx.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Customers = EFCustomerContext.GetCustomers();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Account account)
        {
            EFAccountContext.Create(account);

            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult List()
        {
            List<Account> accounts = EFAccountContext.GetAccounts();
            string data = JsonConvert.SerializeObject(accounts);
            TempData["AccountsList"] = data;
            return View(accounts);
        }
        [HttpGet]
        public IActionResult Download()
        {
            
            string accountsJson =(string)TempData["AccountsList"];
            return Content(accountsJson);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Account account = EFAccountContext.GetAccountById(id);
            return View(account);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Account account = EFAccountContext.GetAccountById(id);
            return View(account);
        }
        [HttpPost]
        public IActionResult Delete(Account account)
        {
            EFAccountContext.Delete(account.Id);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Account account = EFAccountContext.GetAccountById(id);
            return View(account);
        }
        [HttpPost]
        public IActionResult Edit(Account account)
        {
            EFAccountContext.UpdateAccount(account);
            return RedirectToAction("List");

        }
    }
}