using Basket.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<BasketSettings>(builder.Configuration);

var options = builder.Configuration.Get<BasketSettings>();

builder.Services.RegisterKeyCloak(options);

builder.Services.RegisterSwaggerService();

builder.ConfigKestrel();

builder.Services.RegisterGrpcService(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterSwaggerService();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.RegisterInfrastructureServices();

builder.Services.AddBasketDbContext(builder.Configuration);

builder.Services.RegisterMasstransitService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.SwaggerConfig(options);

}

app.BasketMigrateAndSeed().Wait();


app.MapControllers();

app.Run();