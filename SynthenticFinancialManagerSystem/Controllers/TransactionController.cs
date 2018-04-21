using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SynthenticFinancialManagerSystem.Core.Entities;
using SynthenticFinancialManagerSystem.Services.Business;

namespace SynthenticFinancialManagerSystem.WebApp.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public IActionResult Index()
        {
            ETransactionSearch transactionSearch = new ETransactionSearch
            {
                Transactions = _transactionService.List().Result,
                Search = new ESearch() { TransactionDate = DateTime.Now }
            };

            return View(transactionSearch);
        }

        [HttpGet]        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ETransaction transaction)
        {
            var ok = await _transactionService.Save(transaction);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Fraud()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(ESearch search)
        {
            var transactions = _transactionService.Search(search);

            ETransactionSearch transactionSearch = new ETransactionSearch
            {
                Transactions = transactions.Result,
                Search = new ESearch() { TransactionDate = DateTime.Now }
            };

            return View("Index", transactionSearch);
        }

        [HttpPost]
        public async Task<IActionResult> Mark(int step)
        {
            var ok = await _transactionService.Mark(step);

            return RedirectToAction("Index");
        }
    }
}