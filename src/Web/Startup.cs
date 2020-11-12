using ApplicationCore.Interfaces;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.EventStore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Infrustructure;

namespace Web
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
            //ConfigureInMemoryDatabases(services);
            ConfigureProductionServices(services);

            services.AddControllersWithViews();
            services.AddMediatR(typeof(Startup));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();

            ConfigureAutoMapper(services);

            services.AddControllers();
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
                app.UseHsts();
            }

            SeedDb(app);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "defaultApi",
                //    pattern: "api/{controller}/{action}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
        }

        private static void SeedDb(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ContactContext>();
                ContactContextSeed.SeedData(context);
            }
        }

        private void ConfigureInMemoryDatabases(IServiceCollection services)
        {
            services.AddDbContext<ContactContext>(c =>
                c.UseInMemoryDatabase("ZevitDb"));

        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<ContactContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("ContactConnection")));
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
