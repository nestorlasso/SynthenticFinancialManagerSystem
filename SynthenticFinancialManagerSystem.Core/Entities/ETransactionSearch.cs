using System;
using System.Collections.Generic;
using System.Text;

namespace SynthenticFinancialManagerSystem.Core.Entities
{
    public class ETransactionSearch
    {
        public IEnumerable<ETransaction> Transactions { get; set; }
        public ESearch Search { get; set; }
    }
}
