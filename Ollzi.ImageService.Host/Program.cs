using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ollzi.ImageService.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var webHost = new WebHostBuilder()
              .UseKestrel()
              .UseStartup<Program>()
              .Build();

            webHost.Run();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Information);
            app.UseMvc();
        }
    }
}
