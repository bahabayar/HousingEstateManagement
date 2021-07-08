using HousingEstateManagement.Core.Repositories;
using HousingEstateManagement.Core.Services;
using HousingEstateManagement.Core.Services.APIServices;
using HousingEstateManagement.Core.UnitOfWorks;
using HousingEstateManagement.Data.Context;
using HousingEstateManagement.Data.Repositories;
using HousingEstateManagement.Data.UnitOfWorks;
using HousingEstateManagement.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HousingEstateManagement.Service.Dependencies
{
    public static class DependencyContainer
    {
        public static IServiceCollection DependencyExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IPaymentAPIService, PaymentAPIService>();
            
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IExpenseTypeRepository, ExpenseTypeRepository>();
            services.AddScoped<IFlatRepository, FlatRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IExpenseTypeService, ExpenseTypeService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IFlatService, FlatService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}