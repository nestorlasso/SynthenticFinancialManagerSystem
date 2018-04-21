using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynthenticFinancialManagerSystem.Core.Entities
{
    [DataContract]
    public class ETransaction
    {
        public int IdTransaction { get; set; }

        [DataMember(IsRequired = true), Required]
        public ETransactionType Type { get; set; }

        [DataMember(IsRequired = true), Required]
        public decimal Amount { get; set; }

        [DataMember(IsRequired = true), Required]
        public string NameOrig { get; set; }

        [DataMember(IsRequired = true), Required]
        public string NameDest { get; set; }

        
        public bool? IsFraud { get; set; }

        
        public DateTime TransactionDate { get; set; }
    }
}
