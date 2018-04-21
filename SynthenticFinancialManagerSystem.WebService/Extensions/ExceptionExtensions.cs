using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynthenticFinancialManagerSystem.WebService.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetDetail(this Exception ex)
        {
            string error = ex.GetBaseException().Message;

            try
            {
                List<string> errorsValue = new List<string>();
                List<string> errorsName = new List<string>();

                foreach (var item in ex.GetBaseException().Data.Values)
                    errorsValue.Add(item.ToString());

                foreach (var item in ex.GetBaseException().Data.Keys)
                    errorsName.Add(item.ToString());

                int index = errorsName.FindIndex(x => x.Contains("Detail"));
                string detail = errorsValue[index];

                if (!string.IsNullOrEmpty(detail))
                    return error + " - " + detail;
            }
            catch (Exception)
            {
            }

            return error;
        }
    }
}
