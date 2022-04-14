using employeeshift.api.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace employeeshift.api
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddControllers();
            services.AddDbContext<EmployeeShiftContext>(options =>
            {
                options.UseSqlServer(_config["ConnectionStrings:DefaultConnection"], b =>
                    b.MigrationsAssembly("Insfrastructure"));
            }, ServiceLifetime.Scoped);

            services.AddApplicationServices();
            services.AddSwaggerDocumentation();
            services.AddRouting(options => options.LowercaseUrls = true);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseSwaggerDocumentation();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
