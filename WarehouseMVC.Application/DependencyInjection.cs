using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Application.Services;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IImageModelService, ImageModelService>(); // Indicate implementation for us Interfaces 
            services.AddTransient<IQuestionnaireService, QuestionnaireService>(); // Indicate implementation for us Interfaces 
            services.AddTransient<IApplyCountImageModelService, ApplyCountImageModelService>();
            services.AddTransient<IContactService, ContactService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}