using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StoreDB;
using StoreDB.Repos;
using StoreLib;

namespace StoreAPI
{
    public class Startup
    {
        //CORS Policy
        readonly string AllowedOrigins = "allowedOrigins"; 

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy(name: AllowedOrigins,
                    builder => {
                        builder.WithOrigins("*") //http://127.0.0.1:5500
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });


            services.AddControllers();
            services.AddDbContext<StoreContext>(options => options.UseNpgsql(Configuration.GetConnectionString("StoreDB")));

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepo, DBRepo>();

            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ILocationRepo, DBRepo>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepo, DBRepo>();

            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<ICartItemRepo, DBRepo>();

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartRepo, DBRepo>();

            services.AddScoped<ILineItemService, LineItemService>();
            services.AddScoped<ILineItemRepo, DBRepo>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepo, DBRepo>();

            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IInventoryItemRepo, DBRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(AllowedOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
