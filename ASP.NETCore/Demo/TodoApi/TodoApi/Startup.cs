﻿using System;
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
using Microsoft.OpenApi.Models;
using TodoApi.Data.Models;
using System.Net.Http;
using TwelveDataSharp;
using TodoApi.Data;

namespace TodoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("twelveData", c =>
            {
                c.BaseAddress = new Uri("https://api.twelvedata.com/");
            });
            //services.AddSingleton(new TwelveDataClient("80576d2956804a20b19f71a0a9f15469", new HttpClient()));
            services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddDbContext<TodoContext>(opt => opt
                .UseInMemoryDatabase("TodoList"));
            services.AddDbContext<TwelveDataContext>(opt => opt
                .UseInMemoryDatabase("TwelveDataList"));
            //services.AddScoped<ITwelveDataService, TwelveDataService>();

            ////Swagger configuration
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoApi", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            //app.UseSwagger();

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //});

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute(
                //   name: "default",
                //   pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
