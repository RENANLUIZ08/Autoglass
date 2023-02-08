using Autoglass.Domain.DTO;
using Autoglass.Domain.Entities;
using Autoglass.Domain.Repository.Interfaces;
using Autoglass.Repository.Implementations;
using Autoglass.Service.Implementations;
using Autoglass.Service.Repository.Interfaces;
using Autoglass.Service.Service.Implementations;
using Autoglass.Service.Service.Interfaces;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Autoglass.Api.StartupConfig
{
    public static class DependencyInjectConfig
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            #region AutoMapper
            var config = new MapperConfiguration(configuration =>
            {
                //Product
                configuration.CreateMap<Product, ProductDto>().ReverseMap();

                //Provider
                configuration.CreateMap<Provider, ProviderDto>().ReverseMap();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProviderRepository, ProviderRepository>();
            //services.AddTransient(typeof(IServiceBase<>));
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProviderService, ProviderService>();
        }
    }
}
