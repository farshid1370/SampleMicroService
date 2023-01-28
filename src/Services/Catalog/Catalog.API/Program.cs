using Catalog.Infrastructure.Infrastructure.ConfigurationExtension;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 80, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
    });
    options.Listen(IPAddress.Any, 81, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});

builder.Services.AddGrpc(options =>
{
    options.EnableDetailedErrors = true;

});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo { Title = "Catalog gRPC", Version = "v1" });
});


builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.RegisterInfrastructureServices();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog gRPC V1");
    });
}




app.MapGrpcService<CatalogService>();

app.Run();
