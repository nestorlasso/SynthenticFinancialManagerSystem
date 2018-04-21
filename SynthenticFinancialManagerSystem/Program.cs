using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SynthenticFinancialManagerSystem.Data.Model.Entities;
using SynthenticFinancialManagerSystem.Services.Model;

namespace SynthenticFinancialManagerSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run();

            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DbServiceContext>();

                    context.Database.EnsureDeleted();
                    if (context.Database.EnsureCreated())
                    {
                        var actions = new Data.Model.Entities.Action[]
                        {
                            new Data.Model.Entities.Action { ActionName = "Register", IdAction = 1 },
                            new Data.Model.Entities.Action { ActionName = "Search", IdAction = 2 },
                            new Data.Model.Entities.Action { ActionName = "Mark", IdAction = 3 }
                        };
                        context.Action.AddRange(actions);
                        context.SaveChanges();

                        var roles = new Role[]
                        {
                            new Role{ RoleName="Assistant", CreationDate = DateTime.Now, CreateBy = "administrador"},
                            new Role{ RoleName="Manager", CreationDate = DateTime.Now, CreateBy = "administrador"},
                            new Role{ RoleName="Administrator", CreationDate = DateTime.Now, CreateBy = "administrador"}
                        };
                        context.Role.AddRange(roles);
                        context.SaveChanges();

                        var actionsRoles = new ActionRole[]
                        {
                            new ActionRole{Role="Assistant",IdAction=1,CreationDate = DateTime.Now,CreateBy="superAdministrador"},
                            new ActionRole{Role="Assistant",IdAction=2,CreationDate = DateTime.Now,CreateBy="superAdministrador"},
                            new ActionRole{Role="Manager",IdAction=3,CreationDate = DateTime.Now,CreateBy="superAdministrador"},
                            new ActionRole{Role="Administrator",IdAction=1,CreationDate = DateTime.Now,CreateBy="superAdministrador"},
                            new ActionRole{Role="Administrator",IdAction=2,CreationDate = DateTime.Now,CreateBy="superAdministrador"},
                            new ActionRole{Role="Administrator",IdAction=3,CreationDate = DateTime.Now,CreateBy="superAdministrador"}
                        };
                        context.ActionRole.AddRange(actionsRoles);
                        context.SaveChanges();
                    }
                    else
                    {
                        context.Database.Migrate();
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
    }
}
