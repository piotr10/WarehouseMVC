using Microsoft.Extensions.DependencyInjection;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Infrastructure.Repositories;

namespace WarehouseMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IImageModelRepository, ImageModelRepository>();
            services.AddTransient<IQuestionnaireRepository, QuestionnaireRepository>();
            services.AddTransient<IApplyCountImageModelRepository, ApplyCountImageModelRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();

            return services;
        }
    }
}