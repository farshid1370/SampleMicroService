var builder = WebApplication.CreateBuilder(args);

builder.ConfigKestrel();

builder.Services.RegisterGrpcService(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterSwaggerService();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.RegisterInfrastructureServices();

builder.Services.AddBasketDbContext(builder.Configuration);

builder.Services.RegisterMasstransitService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.SwaggerConfig();

}

app.BasketMigrateAndSeed().Wait();


app.MapControllers();

app.Run();