using Microsoft.Extensions.DependencyInjection;

namespace OpenAI.Business.IoC
{
    public static class ModuleInjector
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            //services.AddTransient<IValidator<Project>, ProjectValidator>();

           

            return services;
        }
    }
}
