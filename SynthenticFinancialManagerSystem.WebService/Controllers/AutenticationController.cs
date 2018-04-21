using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using SynthenticFinancialManagerSystem.Core.Entities;
using SynthenticFinancialManagerSystem.Services.Business;

namespace SynthenticFinancialManagerSystem.WebService.Controllers
{
    [Produces("application/json")]
    [Route("Autentication")]
    public class AutenticationController : Controller
    {
        const string TAG = "Autentication";
        private readonly SecurityService _securityService;

        public AutenticationController(SecurityService securityService)
        {
            _securityService = securityService;
        }

        [AllowAnonymous]
        [SwaggerOperation(Tags = new[] { TAG })]
        [HttpPost, Route("Token")]
        public IActionResult CreateToken([FromBody]LoginToken login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IActionResult response = Unauthorized();
            var validated = _securityService.AuthenticateAsync(login);

            if (validated.Result)
            {
                var tokenString = _securityService.BuildToken(login);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
    }
}