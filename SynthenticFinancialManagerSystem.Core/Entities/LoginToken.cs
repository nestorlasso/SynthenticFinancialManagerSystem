using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SynthenticFinancialManagerSystem.Core.Entities
{
    [DataContract]
    public class LoginToken
    {
        [DataMember, Required]
        public string Username { get; set; }

        [DataMember, Required]
        public string Password { get; set; }

        [DataMember(IsRequired = true), Required]
        public int DurationToken { get; set; }
    }
}
