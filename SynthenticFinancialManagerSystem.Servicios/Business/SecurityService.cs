using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SynthenticFinancialManagerSystem.Core.Entities;
using SynthenticFinancialManagerSystem.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthenticFinancialManagerSystem.Services.Business
{
    public class SecurityService
    {
        private readonly SignInManager<User> _signInManager;
        private IConfiguration _config;
        private readonly RoleService _roleService;


        public SecurityService(IConfiguration config, SignInManager<User> signInManager, RoleService roleService)
        {
            _config = config;
            _signInManager = signInManager;
            _roleService = roleService;
        }

        public string BuildToken(LoginToken login)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<System.Security.Claims.Claim> claims = new List<System.Security.Claims.Claim>{
                new System.Security.Claims.Claim("username", login.Username) };

            JwtSecurityToken token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims: claims,
              expires: DateTime.Now.AddHours(login.DurationToken),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> AuthenticateAsync(LoginToken login)
        {
            bool ok = false;
            var result = await _signInManager.PasswordSignInAsync(login.Username, login.Password, false, false);

            if (result.Succeeded)
                ok = _roleService.GetActionsByUser(login.Username).Any(x => x.ActionName == "Search" || x.ActionName == "Register");

            return result.Succeeded && ok;
        }
    }
}
