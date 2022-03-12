using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProyectoEstructura.Entities.Interfaces;
using ProyectoEstructura.Repositories.EFCore.DataContext;
using ProyectoEstructura.Repositories.EFCore.Repositories;
using ProyectoEstructura.UseCases.Common.Behaviors;
using ProyectoEstructura.UseCases.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructura.IoC
{
   public static class DependencyContainer
    {
        public static  IServiceCollection AddProyectoEstructuraServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ProyectoEstructuraContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PruebaCleanArchitectureDb")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddMediatR(typeof(CreateOrderInteractor));
            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;

        }
    }
}
