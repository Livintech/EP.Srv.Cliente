using AspNet.Security.OAuth.Validation;
using EP.Srv.Cliente.CrossCutting.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HostFiltering;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfigurations();
builder.Services.AddConfigurationServices();
builder.Services.AddConfigurationMediatR();
builder.Services.AddConfigurationsJson();
builder.Services.AddConfigurationsContext(options =>
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

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
          (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

//builder.Services.AddAuthentication(OAuthValidationDefaults.AuthenticationScheme).AddOAuthValidation();

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