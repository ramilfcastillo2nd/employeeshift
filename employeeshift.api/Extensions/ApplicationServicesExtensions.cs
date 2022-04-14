using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace employeeshift.api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IShiftRepository, ShiftRepository>();
            services.AddScoped<IEmployeeWorksShiftRepository, EmployeeWorksShiftRepository>();
            services.AddScoped<IEmployeeShiftService, EmployeeShiftService>();
            return services;
        }
    }
}
