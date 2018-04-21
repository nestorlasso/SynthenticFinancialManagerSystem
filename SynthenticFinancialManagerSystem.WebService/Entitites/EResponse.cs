using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynthenticFinancialManagerSystem.WebService.Entitites
{
    public class EResponse
    {
        public EResponse()
        {
            Code = "0";
            Desc = "OK";
        }

        public string Code { get; set; }
        public string Desc { get; set; }
    }
}
