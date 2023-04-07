using Enoca.DataAccess.Repositories.IRepositories;
using Enoca.DataAccess.Repositories;
using Enoca.Entity.Repositories.IRepositories;
using Enoca.Entity.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace OpenAI.DataAccess.IoC
{
    public static class ModuleInjector
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {

            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            ////services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            ////services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            ////services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            //services.AddScoped<IAuthService, AuthManager>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            return services;
        }
    }

}
