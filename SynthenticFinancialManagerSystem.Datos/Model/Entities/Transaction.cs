using System;

namespace SynthenticFinancialManagerSystem.Data.Model.Entities
{
    public class Transaction
    {
        public int IdTransaction { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string NameOrig { get; set; }
        public string NameDest { get; set; }
        public bool? IsFraud { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
