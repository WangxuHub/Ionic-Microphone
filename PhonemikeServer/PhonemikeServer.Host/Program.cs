using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PhonemikeServer.WebApi;

namespace PhonemikeServer.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            
            host.Run();

            while (true)
            {
                var inputStr = Console.ReadLine();

                if (inputStr == "stop")
                {
                    host.Dispose();
                    break;
                }
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var host =    WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

            return host;
        }
    }
}
