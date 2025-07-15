using Microsoft.EntityFrameworkCore;
using Report_API.Controllers;

namespace Report_API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DietDbContext>(options =>
    options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            //seed из DbInitializer
            //using (var scope = app.ApplicationServices.CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<DietDbContext>();
            //    DbInitializer.Seed(context);
            //}

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
