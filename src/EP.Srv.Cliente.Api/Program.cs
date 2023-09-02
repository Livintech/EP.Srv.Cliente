using EP.Srv.Cliente.CrossCutting.Configurations;
using Microsoft.AspNetCore.HostFiltering;
using Microsoft.AspNetCore.Http;
using Serilog;

//[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfigurations();
builder.Services.AddConfigurationServices();
builder.Services.AddConfigurationMediatR();
builder.Services.AddServicesConfigurations(options =>
{
    options.DbConnectionString = builder.Configuration.GetConnectionString("DbConnectionString")!;
    options.MySqlVersion = builder.Configuration.GetConnectionString("MySqlVersion")!;
});

builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .Enrich.FromLogContext()
        .WriteTo.MySQL(builder.Configuration.GetConnectionString("DbConnectionString"));
});

builder.WebHost.ConfigureKestrel(c =>
{
    c.Limits.MinResponseDataRate = null;
    c.Limits.MinRequestBodyDataRate = null;
    c.Limits.MaxRequestBodySize = 20000000;
    c.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(15);
})
.UseIIS()
.UseIISIntegration();

builder.WebHost.ConfigureAppConfiguration((hostingCOntext, config) =>
{
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();