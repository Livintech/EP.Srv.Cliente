using MediatR;
using EP.Srv.Cliente.Application.Handlers.CommandoHandlers;
using EP.Srv.Cliente.CrossCutting.Options;
using EP.Srv.Cliente.Infrastructure.Context;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using EP.Srv.Cliente.LogUtility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using EP.Srv.Cliente.Domain.Commands.Cliente;
using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Application.Services;
using EP.Srv.Cliente.Infrastructure.Repositories;
using EP.Srv.Cliente.Domain.Commands.Banco;
using EP.Srv.Cliente.Application.Handlers.CommandHandlers;
using Microsoft.AspNetCore.Http;
using EP.Srv.Cliente.Domain.Interfaces;
using EP.Srv.Cliente.Infrastructure.Identity;
using System.Text.Json.Serialization;
using EP.Srv.Cliente.Domain.Commands.Pagamento;
using EP.Srv.Cliente.Domain.Commands.CentroCusto;
using EP.Srv.Cliente.Domain.Commands.Empresa;
using EP.Srv.Cliente.Application.Handlers.QueryHandlers;
using EP.Srv.Cliente.Domain.Commands.PlanoContas;
using EP.Srv.Cliente.Domain.Commands.ContasPagar;

namespace EP.Srv.Cliente.CrossCutting.Configurations
{
    public static class AddInfractructureExtensions
    {
        public static IServiceCollection AddConfigurationServices(this IServiceCollection services) 
        {
            //configure services
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserIdentity, UserIdentity>();

            services.AddScoped<ILoggerHelper, LoggerHelper>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IBancoService, BancoService>();
            services.AddScoped<IBancorepository, Bancorepository>();

            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            services.AddScoped<IFormaPagamentoService, FormaPagamentoService>();
            services.AddScoped<IFormaPagamentosRepository, FormaPagamentosRepository>();

            services.AddScoped<ICentroCustosService, CentroCustosService>();
            services.AddScoped<ICentroDeCustoRepository, CentroDeCustoRepository>();

            services.AddScoped<IProdutosServicosService, ProdutosServicosService>();
            services.AddScoped<IProdutosServicosRepository, ProdutosServicosRepository>();

            services.AddScoped<IPlanoDeContasService, PlanoDeContasService>();
            services.AddScoped<IPlanoDeContasRepository, PlanoDeContasRepository>();

            services.AddScoped<IContasPagarService, ContasPagarService>();
            services.AddScoped<IContasPagarRepository, ContasPagarRepository>();

            return services;
        }

        public static IServiceCollection AddConfigurationMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(CadastroClienteCommand).Assembly);
            services.AddMediatR(typeof(AtualizarClienteCommand).Assembly);
            services.AddMediatR(typeof(ClienteCommandHandler).Assembly);
            services.AddMediatR(typeof(ListarClientesCommand).Assembly);
            services.AddMediatR(typeof(ListarTodosClientesQueryHandler).Assembly);

            services.AddMediatR(typeof(ListarEmpresasCommand).Assembly);
            services.AddMediatR(typeof(CadastrarEmpresaCommand).Assembly);
            services.AddMediatR(typeof(AtualizarEmpresaCommand).Assembly);
            services.AddMediatR(typeof(EmpresaCommandHandler).Assembly);

            services.AddMediatR(typeof(CadastroBancoCommand).Assembly);
            services.AddMediatR(typeof(ListarBancosCommand).Assembly);
            services.AddMediatR(typeof(ObterBancoByIdCommand).Assembly);
            services.AddMediatR(typeof(AtualizarBancoCommand).Assembly);
            services.AddMediatR(typeof(BancoCommandHandler).Assembly);

            services.AddMediatR(typeof(CadastrarFormaPagamentosCommand).Assembly);
            services.AddMediatR(typeof(ListarFormaPagamentosCommand).Assembly);
            services.AddMediatR(typeof(AtualizaFormaPagamentosCommand).Assembly);
            services.AddMediatR(typeof(FormaPagamentosCommandHandler).Assembly);

            services.AddMediatR(typeof(GravarCentroCustoCommand).Assembly);
            services.AddMediatR(typeof(ListarCentroCustoCommand).Assembly);
            services.AddMediatR(typeof(AtualizarCentroCustoCommand).Assembly);
            services.AddMediatR(typeof(CentroDeCustoCommandHandler).Assembly);

            services.AddMediatR(typeof(CadastrarPlanoContasCommand).Assembly);
            services.AddMediatR(typeof(ListarPlanoContasCommand).Assembly);
            services.AddMediatR(typeof(AtualizarPlanoContasCommand).Assembly);
            services.AddMediatR(typeof(PlanoContasCommandHandler).Assembly);

            services.AddMediatR(typeof(CadastrarLancamentoCommand).Assembly);
            services.AddMediatR(typeof(ListarLancamentoCommand).Assembly);
            services.AddMediatR(typeof(AtualizarLancamentoCommand).Assembly);

            return services;
        }

        public static IServiceCollection AddConfigurationsContext(this IServiceCollection services, Action<AppSettingsOptions> appSettingsOptions)
        {
            ArgumentNullException.ThrowIfNull(services, nameof(services));
            ArgumentNullException.ThrowIfNull(appSettingsOptions, nameof(appSettingsOptions));

            //configure options
            services.Configure(appSettingsOptions);

            AppSettingsOptions _appSettingsOptions = new AppSettingsOptions();
            appSettingsOptions.Invoke(_appSettingsOptions);

            //configure dbContext
            services.AddDbContext<IAppDbContext, AppDbContext>(options =>
            {
                options.UseMySql(_appSettingsOptions.DbConnectionString, new MySqlServerVersion(new Version(_appSettingsOptions.MySqlVersion)));
            });

            return services;
        }

        public static IServiceCollection AddSwaggerConfigurations(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services, nameof(services));

            //configure swagger version
            services.AddApiVersioning(config =>
            {
                config.ReportApiVersions = true;
                config.UseApiBehavior = true;
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Token de autenticação.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                 {
                    {
                        new OpenApiSecurityScheme
                            {
                                 Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                                 Name = "Authorization",
                                 In = ParameterLocation.Header,
                                 Type = SecuritySchemeType.Http,
                                 Scheme = "Bearer"
                            },
                            new List<string>()
                    }
                });
            });

            //configure options
            services.ConfigureOptions<SwaggerOptions>();

            return services;

        }

        public static IServiceCollection AddConfigurationsJson(this IServiceCollection services, Action<JwtOptions> jwtOpt)
        {
            services.Configure(jwtOpt);
            services.AddSingleton(jwtOpt);
            services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options 
                => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            return services;
        }
    }
}
