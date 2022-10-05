using JFS.BusinessLogicLayer.Builders;
using JFS.BusinessLogicLayer.Services;
using JFS.BusinessLogicLayer.Services.Abstract;
using JFS.DataAccessLayer.Context;
using JFS.DataAccessLayer.Repositories;
using JFS.DataAccessLayer.Repositories.Abstract;

namespace JFS.WebApi.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IFilesContext, FilesContext>();
            services.AddScoped<IBalanceRepository, BalanceRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IBalanceService, BalanceService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddTransient<IReportBuilder, ReportBuilder>();

            return services;
        }
    }
}
