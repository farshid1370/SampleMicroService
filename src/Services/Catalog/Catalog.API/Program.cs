

var builder = WebApplication.CreateBuilder(args);

builder.ConfigKestrel();

builder.Services.RegisterGrpcService();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterSwaggerService();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.RegisterInfrastructureServices();

builder.Services.AddCatalogDbContext(builder.Configuration);

builder.Services.RegisterMasstransitService();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.SwaggerConfig();

}

app.MigrateDataBase<Program>((services) =>
{
    var context = services.GetService<CatalogContext>();
    if (context != null) new CatalogContextSeed().MigrateAndSeed(context).Wait();
});

app.GrpcConfig();

app.MapControllers();

app.Run();
