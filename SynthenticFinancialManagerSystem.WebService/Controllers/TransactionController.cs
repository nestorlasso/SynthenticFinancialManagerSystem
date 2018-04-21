using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using SynthenticFinancialManagerSystem.Core.Entities;
using SynthenticFinancialManagerSystem.Services.Business;
using SynthenticFinancialManagerSystem.WebService.Entitites;
using SynthenticFinancialManagerSystem.WebService.Extensions;
using System;
using System.Threading.Tasks;

namespace SynthenticFinancialManagerSystem.WebService.Controllers
{
    [Produces("application/json")]
    [Route("Transaction")]
    [Authorize]
    public class TransactionController : Controller
    {
        const string TAG = "Transactions";
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost, Route("Register")]
        [SwaggerOperation(Tags = new[] { TAG })]
        public async Task<IActionResult> PostRegister([FromBody] ETransaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var guardo = await _transactionService.Save(transaction);

                if (guardo)
                    return Ok(new EResponse());
                else
                    return Ok(new EResponse() { Code = "1", Desc = "Transaction fail" });
            }
            catch (Exception ex)
            {
                return Ok(new EResponse() { Code = "2", Desc = ex.GetDetail() });
            }
        }

        [HttpPost, Route("Search")]
        [SwaggerOperation(Tags = new[] { TAG })]
        public async Task<IActionResult> SearchTransactions([FromBody] ESearch search)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var transactions = await _transactionService.Search(search);

                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return Ok(new EResponse() { Code = "2", Desc = ex.GetDetail() });
            }
        }
    }
}