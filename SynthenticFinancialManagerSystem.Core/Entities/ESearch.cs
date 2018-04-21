using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace SynthenticFinancialManagerSystem.Core.Entities
{
    [DataContract]
    public class ESearch
    {
        [DataMember]
        public bool IsFraud { get; set; }

        [DataMember]
        public string NameDest { get; set; }

        [DataMember]
        public DateTime? TransactionDate { get; set; }
    }
}
