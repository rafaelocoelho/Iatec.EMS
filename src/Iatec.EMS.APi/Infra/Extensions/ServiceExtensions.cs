using AutoMapper;
using Iatec.EMS.Api.Infra.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Iatec.EMS.Api.Infra.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {
            #region Mapper  
            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);
            #endregion

            return services;
        }
    }
}
