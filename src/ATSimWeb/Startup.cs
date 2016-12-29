using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ATSimWeb.Config;
using ATSimCommon;
using Newtonsoft.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SimpleTokenProvider;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.DataProtection;
using System.IO;

namespace ATSimWeb
{
    public partial class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc().AddJsonOptions(option =>
            {
                option.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            services.AddDataProtection()
                .SetApplicationName("ATSim_DotNetCore")
                .ProtectKeysWithDpapi()
                .PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory()));
            new Encryption().CreateProtector(services.BuildServiceProvider().GetDataProtectionProvider());

            new InjectionService(services);
            MapperConfiguration.Configuration();
            ErrorMessageManagement.Init();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            ConfigureAuth(app);
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
