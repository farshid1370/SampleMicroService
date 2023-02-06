var builder = WebApplication.CreateBuilder(args);

builder.ConfigKestrel();

builder.Services.RegisterGrpcService();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterSwaggerService();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.RegisterInfrastructureServices();

builder.Services.AddCatalogDbContext(builder.Configuration);

builder.Services.AddIntegrationEventLogDbContext(builder.Configuration);

builder.Services.RegisterMasstransitService();

builder.Services.Configure<CatalogSetting>(builder.Configuration);

builder.Services.AddIntegrationEventLogService();

builder.Services.AddHostedService<IntegrationEventPublishWorker>();

builder.Services.RegisterBehaviors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.SwaggerConfig();

}

app.CatalogMigrateAndSeed().Wait();

app.IntegrationEventLogMigrate().Wait();

app.GrpcConfig();

app.MapControllers();

app.Run();
