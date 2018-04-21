using SynthenticFinancialManagerSystem.Data.Model.Entities;
using SynthenticFinancialManagerSystem.Services.Context;
using SynthenticFinancialManagerSystem.Services.Model;
using System.Collections.Generic;
using System.Linq;

namespace SynthenticFinancialManagerSystem.Services.Business
{
    public class RoleService
    {
        private readonly DbServiceContext _context;

        public RoleService(IDbContextGeneric context)
        {
            _context = context.GetContext();
        }

        public IEnumerable<Role> GetRoles()
        {
            return _context.Role;
        }

        public IEnumerable<Action> GetActionsByUser(string user)
        {
            var actions = (from f in _context.Action
                           join fr in _context.ActionRole on f.IdAction equals fr.IdAction
                           join ur in _context.UserRole on fr.Role equals ur.Role
                           where ur.IdUserNavigation.UserName == user
                           orderby f.IdAction
                           select f).GroupBy(g => g.ActionName).Select(s => s.First());

            return actions;
        }
    }
}