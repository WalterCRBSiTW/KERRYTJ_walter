using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Homework02.Models;
using Microsoft.EntityFrameworkCore;
using Homework02.Factory;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;

namespace Homework02
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddCors(options => options.AddPolicy("CorsPolicy", build =>
            //{
            //    build.SetIsOriginAllowed(origin => true)
            //        .AllowAnyHeader()
            //        .AllowAnyMethod()
            //        .AllowCredentials();
            //}));


            //建立資料庫連線
            //services.AddDbContext<HomeworkDBContext>(options => {
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //});
            //註冊服務
            var connection = @"Server=(LocalDb)\MSSQLLocalDB;Database=HomeworkDB;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<HomeworkDBContext>(options => options.UseSqlServer(connection));

            //連結前端 跨域請求 Cross-Origin Requests (CORS)
            services.AddCors(options =>
            {
                // AllowCors 是自訂的 Builder 名稱
                options.AddPolicy("AllowCors", 
                policy =>
                            {
                                policy.WithOrigins("http://localhost:4210")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                            });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            
            //Autofac注入
            ContainerBuilder builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                                    .Where(t => t.GetCustomAttribute<DependencyRegisterAttribute>() != null)
                                    .AsImplementedInterfaces();

            var container = builder.Build();
            return new AutofacServiceProvider(container);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //跨域請求 Cross-Origin Requests (CORS)
            app.UseCors("AllowCors");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
