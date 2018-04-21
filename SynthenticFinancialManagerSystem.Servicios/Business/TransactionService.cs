using Microsoft.EntityFrameworkCore;
using SynthenticFinancialManagerSystem.Core.Entities;
using SynthenticFinancialManagerSystem.Data.Model.Entities;
using SynthenticFinancialManagerSystem.Services.Context;
using SynthenticFinancialManagerSystem.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynthenticFinancialManagerSystem.Services.Business
{
    public class TransactionService
    {
        private readonly DbServiceContext _context;

        public TransactionService(IDbContextGeneric context)
        {
            _context = context.GetContext();
        }

        public async Task<IEnumerable<ETransaction>> List()
        {
            var transactions = (from t in _context.Transaction
                                select new ETransaction
                                {
                                    Amount = t.Amount,
                                    IsFraud = t.IsFraud,
                                    NameDest = t.NameDest,
                                    NameOrig = t.NameOrig,
                                    IdTransaction = t.IdTransaction,
                                    Type = (ETransactionType)Enum.Parse(typeof(ETransactionType), t.Type),
                                    TransactionDate = DateTime.Now
                                });

            return await transactions.ToListAsync();
        }

        public async Task<IEnumerable<ETransaction>> Search(ESearch search)
        {
            var transactions = (from t in _context.Transaction
                                select new ETransaction
                                {
                                    Amount = t.Amount,
                                    IsFraud = t.IsFraud,
                                    NameDest = t.NameDest,
                                    NameOrig = t.NameOrig,
                                    IdTransaction = t.IdTransaction,
                                    Type = (ETransactionType)Enum.Parse(typeof(ETransactionType), t.Type),
                                    TransactionDate = t.TransactionDate
                                });

            if (!string.IsNullOrEmpty(search.NameDest))
                transactions = transactions.Where(x => x.NameDest == search.NameDest);

            if (search.IsFraud)
                transactions = transactions.Where(x => x.IsFraud == search.IsFraud);

            if(search.TransactionDate != null)
                transactions = transactions.Where(x => x.TransactionDate.Date == search.TransactionDate.Value.Date);

            return await transactions.ToListAsync();
        }

        public async Task<bool> Save(ETransaction transaction)
        {
            try
            {
                var _transaction = new Transaction
                {
                    Amount = transaction.Amount,
                    NameDest = transaction.NameDest,
                    NameOrig = transaction.NameOrig,
                    Type = transaction.Type.ToString(),
                    TransactionDate = DateTime.Now
                };

                await _context.Transaction.AddAsync(_transaction);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Mark(int idTransaction)
        {
            try
            {
                var _transaction = _context.Transaction.SingleOrDefault(x => x.IdTransaction == idTransaction);

                _transaction.IsFraud = true;

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
