﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SynthenticFinancialManagerSystem.WebService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .UseIISIntegration()
                .Build();
    }
}
