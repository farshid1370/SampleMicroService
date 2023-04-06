using Catalog.API.Infrastructure.Filters;
using Google.Protobuf.WellKnownTypes;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Common;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CatalogSetting>(builder.Configuration);

var options = builder.Configuration.Get<CatalogSetting>();

builder.Services.RegisterKeyCloak(options);

builder.Services.RegisterSwaggerService();


builder.ConfigKestrel();

builder.Services.RegisterGrpcService();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.RegisterInfrastructureServices();

builder.Services.AddCatalogDbContext(builder.Configuration);

builder.Services.AddIntegrationEventLogDbContext(builder.Configuration);

builder.Services.RegisterMasstransitService();


builder.Services.AddIntegrationEventLogService();

builder.Services.AddHostedService<IntegrationEventPublishWorker>();

builder.Services.RegisterBehaviors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.SwaggerConfig(options);

}

app.CatalogMigrateAndSeed().Wait();

app.IntegrationEventLogMigrate().Wait();

app.GrpcConfig();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
