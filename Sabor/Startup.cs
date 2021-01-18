using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sabor.Business.Abstract;
using Sabor.Business.Concrate;
using Sabor.Data.Abstract;
using Sabor.Data.Concrate.EfCore;
using Sabor.EmailServices;
using Sabor.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sabor
{
    public class Startup
    {
        //private IConfiguration _Configuration;
        //public Startup(IConfiguration configuration)
        //{
        //    _Configuration = Configuration;
        //}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {//Identity Ayarlar�
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("server=.;database=SaborContext;integrated security=true;"));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                //password
                options.Password.RequireDigit = true;//mutalak say�sal de�er girmeli
                options.Password.RequireLowercase = true;//Mutlaka K���k harf olmak   zorunda
                options.Password.RequireUppercase = true;//B�y�k harf
                options.Password.RequiredLength = 6;//min  karakter
                options.Password.RequireNonAlphanumeric = false;

                //Lockout -- Kullan�c� hesab� kilitlenip kilitlenmemesi ile alakal�
                options.Lockout.MaxFailedAccessAttempts = 5;//Yanl�� max 5 parola girebilir.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;//locakoutu aktif ettik

                //User
                options.User.RequireUniqueEmail = true;//her kullan�c� e postas� ayr� olsun
                options.SignIn.RequireConfirmedEmail = true;//hesab� onaylas�n
                

            });

            //cookie
            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/account/login";
                option.LogoutPath = "/account/logout";
                option.AccessDeniedPath = "/account/accessdenied";
                option.SlidingExpiration = true;//login olduktan sonra 20 dk
                option.ExpireTimeSpan = TimeSpan.FromDays(365);
                option.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".Sabor.Security.Cookie"
                };
            });
            
            
            services.AddControllersWithViews();

            services.AddScoped< IProductRepository, ProductRepository>();
            services.AddScoped<IProductServices, ProductManager>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();  
            services.AddScoped<ICategoryServices, CategoryManager>();
            
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IVideoServices, VideoManager>();

            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<ISliderServices, SliderManager>();

            services.AddScoped<IPopularProductRepository, PopularProductRepository>();
            services.AddScoped<IPopularProductServices, PopularProductManager>();

            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactServices, ContactManager>();


            services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
               new SmtpEmailSender(
                   Configuration["EmailSender:Host"],
                   Configuration.GetValue<int>("EmailSender:Port"),
                   Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                   Configuration["EmailSender:UserName"],
                   Configuration["EmailSender:Password"])
              );
            //EMA�L ���N

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                       name: "ProductDetail",
                       pattern: "/Urunler/{Urunid}",
                       defaults: new { controller = "Home", action = "ProductDetail" }
                       );

                endpoints.MapControllerRoute(
                    name: "Product",
                    pattern: "Sbr/Urunler/{category?}/{pages?}",
                    defaults: new { controller = "Home", action = "Productses" }
                    );
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
