using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using ICH.King;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebApi
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;


        public Startup(IHostingEnvironment env)
        {
            _environment = env;

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
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
            services.AddKing<LogisticsContext>(x =>
            {
                x.DbType = DbType.MYSQL;
                x.ConnectionString = "server=10.0.1.148;Database=logistics;Uid=root;Pwd=fuludev;Port=3306;Allow User Variables=True;";
            });
            services.AddTransient<ILogisticsChannelRepository, LogisticsChannelRepository>();
            services.AddTransient<ILogisticsMerchantRepository, LogisticsMerchantRepository>();
            #region 授权验证配置
            //services.AddAuthorizeClient(new Uri(Configuration["Endpoints:Authorize"]), options =>
            //{
            //    options.TokenEndpoint = Configuration["Endpoints:Token"];
            //    options.ClientId = Configuration["AppSettings:ClientId"];
            //    options.ClientSecret = Configuration["AppSettings:ClientSecret"];
            //});
            //services.Authentication(requirement =>
            //{
            //    requirement.ServiceName = AppSettings.ProjectName;
            //    requirement.ClientId = Configuration["AppSettings:ClientId"];
            //    requirement.OpenPlatformEndpoint = Configuration["Endpoints:OpenPlatform"];
            //    requirement.AuthorizeEndpoint = Configuration["Endpoints:Authorize"];
            //});
            //services.Authentication(requirement =>
            //{
            //    requirement.ValidateClient = true;  //开启客户端验证
            //    requirement.ValidateUser = true;   //开启用户权限验证
            //});
            #endregion
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IConfiguration>(Configuration);
            if (!_environment.IsProduction())
                services.AddDocument<Startup>("物流服务", "物流服务WebApi");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            if (!_environment.IsProduction())
                app.UseDocument();
        }
    }
}
