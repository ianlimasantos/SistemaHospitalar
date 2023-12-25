using AutoMapper;
using Cadastro.Application.Mapper;
using Cadastro.Application.Services;
using Cadastro.Application.Services.Interfaces;
using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Services;
using Cadastro.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Cadastro.Infra.IoC
{
    public static class CadastroModule
    {
        private static void ConfigureMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToViewModelProfile());
            });

            services.AddSingleton(mapperConfig.CreateMapper());
        }
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.ConfigureMapper();
            return services;
        }

        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPessoaAppService, PessoaAppService>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IMedicoAppService, MedicoAppService>();
            services.AddScoped<IMedicoService, MedicoService>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IEnderecoConsultorioAppService, EnderecoConsultorioAppService>();
            services.AddScoped<IEnderecoConsultorioService, EnderecoConsultorioService>();
            services.AddScoped<IEnderecoConsultorioRepository, EnderecoConsultorioRepository>();

            return services;
        }
    }
}
