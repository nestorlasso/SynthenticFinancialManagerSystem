using System;

namespace SynthenticFinancialManagerSystem.Data.Model.Entities
{
    public class EntityControl
    {
        public string CreateBy { get; set; }
        public DateTime CreationDate  { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Active { get; set; }
    }
}
