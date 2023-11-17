using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace COSMIC.Elements.Web
{

    
    public class ElementsAspCorePresentation
    {
        public void Start(IContainer container)
        {
            var host = Host.CreateDefaultBuilder(Environment.GetCommandLineArgs())
                .UseServiceProviderFactory(
                    new AutofacChildLifetimeScopeServiceProviderFactory(
                        container.BeginLifetimeScope("root-one")))
                .ConfigureWebHostDefaults(webHostBuilder => { webHostBuilder.UseStartup<ElementsAspCoreStartup>(); })
                .Build();
            host.RunAsync();
        }

        public class ElementsAspCoreStartup
        {
         
            
            private readonly string[] _allowedStaticDirectories = { "vendor", "css", "js", "vue" };
            private readonly IWebHostEnvironment _environment;
            private IConfigurationRoot Configuration { get; set; }

            public ElementsAspCoreStartup(IWebHostEnvironment env)
            {
                _environment = env;
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

                Configuration = builder.Build();
            }


            public void ConfigureServices(IServiceCollection services)
            {
                
                services.AddRazorPages()
                    .WithRazorPagesRoot("/Pages")
                    .AddJsonOptions(options =>
                        options.JsonSerializerOptions.WriteIndented = _environment.IsDevelopment());
            }


            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                    app.UseDeveloperExceptionPage();
                else
                {
                    app.UseExceptionHandler("/Error");
                    app.UseHsts();
                }

                app.UseStatusCodePages();
                app.UseHttpsRedirection();
                app.UseRouting();
                app.UseAuthorization();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapRazorPages();
                    endpoints.MapControllers();
                });

                foreach (string allowedStaticDirectory in _allowedStaticDirectories)
                {
                    app.UseStaticFiles(new StaticFileOptions
                    {
                        RequestPath = $"/{allowedStaticDirectory}",
                        FileProvider =
                            new PhysicalFileProvider(
                                Path.Combine(Environment.CurrentDirectory,
                                    allowedStaticDirectory)),
                        ServeUnknownFileTypes = true
                    });
                }
            }
        }
    }
}