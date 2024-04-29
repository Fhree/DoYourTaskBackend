using DYT.businessLogic.Status.Queries;
using DYT.businessLogic.Tasks.Queries;
using DYT.businessLogic.TypeTask.Queries;
using DYT.repository;
using Microsoft.Extensions.DependencyInjection;

namespace DYT.api.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services) 
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IGetAllTasksQueryHandler, GetAllTasksQueryHandler>();
            services.AddScoped<IGetTaskQueryHandler, GetTaskQueryHandler>();
            services.AddScoped<IGetStatusQueryHandler, GetStatusQueryHandler>();
            services.AddScoped<IGetTypeTaskQueryHandler, GetTypeTaskQueryHandler>();
            
            return services;
        }
    }
}
