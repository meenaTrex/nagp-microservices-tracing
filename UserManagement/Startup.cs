using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using Jaeger.Senders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTracing;
using OpenTracing.Util;
using UserManagement.Services;

namespace UserManagement
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
            services.AddControllers();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            services.AddOptions();
            services.AddTransient<IUserService, UserService>();

            var server = Environment.GetEnvironmentVariable("Server");
            var userId = Environment.GetEnvironmentVariable("UserId");
            var password = Environment.GetEnvironmentVariable("Password");
            var connectionString = $"server={server}; uid={userId}; pwd={password};";

            services.AddTransient<MySqlService>(x => new MySqlService(connectionString));

            var jaeger = Environment.GetEnvironmentVariable("Jagger_Endpoint");
            var endpoint = jaeger == null ? "jaggerservice" : jaeger;

            services.AddSingleton<ITracer>(serviceProvider =>
            {
                string serviceName = Assembly.GetEntryAssembly().GetName().Name;
                ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                ISampler sampler = new ConstSampler(sample: true);

                var reporter = new RemoteReporter.Builder()
                    .WithLoggerFactory(loggerFactory)
                    .WithSender(new UdpSender(endpoint, 6831, 0))
                    .Build();

                ITracer tracer = new Tracer.Builder(serviceName)
                    .WithLoggerFactory(loggerFactory)
                    .WithSampler(sampler)
                    .WithReporter(reporter)
                    .Build();

                GlobalTracer.Register(tracer);
                return tracer;
            });
            services.AddOpenTracing();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
