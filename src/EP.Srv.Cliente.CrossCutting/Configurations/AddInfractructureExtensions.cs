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


namespace EP.Srv.Cliente.CrossCutting.Configurations
{
    public static class AddInfractructureExtensions
    {
        public static IServiceCollection AddConfigurationServices(this IServiceCollection services) 
        {
            //configure services
            services.AddScoped<ILoggerHelper, LoggerHelper>();

            return services;
        }

        public static IServiceCollection AddConfigurationMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddMediatR(typeof(CreateFileCommand).Assembly);
            //services.AddMediatR(typeof(CreateFileCommandHandler).Assembly);

            return services;
        }
        public static IServiceCollection AddServicesConfigurations(this IServiceCollection services, Action<AppSettingsOptions> appSettingsOptions)
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
    }
}
