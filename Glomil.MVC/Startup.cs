using FluentValidation.AspNetCore;
using Glomil.BLL.Services;
using Glomil.DAL;
using Glomil.MVC.RabbitMQ;
using Glomil.MVC.RabbitMQ.BackgroundServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;

namespace Glomil.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(sp => new ConnectionFactory() { Uri = new Uri(Configuration.GetConnectionString("RabbitMQ")), DispatchConsumersAsync=true });
            services.AddSingleton<RabbitMQClientService>();
            services.AddSingleton<RabbitMQPublisher>();
            services.AddHostedService<AnswerProcessBackGroundService>();
           
            services.AddDbContext<GlomilDbContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                y => y.MigrationsAssembly("Glomil.DAL")));

            services.AddScoped<DbContext>(prov => prov.GetService<GlomilDbContext>());

            //Scoped Extension
            services.AddBLLObject();

            //Validation
            services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());

            //Cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/index";
                    x.ExpireTimeSpan = TimeSpan.FromMinutes(1);
                    x.Cookie.Name = "GlomilCookie";
                });

            // Controller Level Authorization
            services.AddMvc(conf =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

                conf.Filters.Add(new AuthorizeFilter(policy));
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
