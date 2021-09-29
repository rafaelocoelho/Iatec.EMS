using Iatec.EMS.Infra.Intefaces;
using Iatec.EMS.Infra.Repositories;
using Iatec.EMS.Services;
using Iatec.EMS.Services.Interfaces;
using Iatec.EMS.Token.Interfaces;
using Iatec.EMS.Token.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Iatec.EMS.IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            #region Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IEventParticipantService, EventParticipantService>();
            #endregion

            #region Repositories
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventParticipantRepository, EventParticipantRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Providers
            services.AddScoped<ITokenProvider, TokenProvider>();
            #endregion

            return services;
        }
    }
}
