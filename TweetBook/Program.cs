using Microsoft.AspNetCore.Builder;
using TweetBook.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "TweetBook API", Version = "v1"});
});

var swaggerOptions = new SwaggerOptions();
builder.Configuration.GetSection("SwaggerOptions").Bind(swaggerOptions);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.UseSwagger(opt =>
{
    opt.RouteTemplate = swaggerOptions.JsonRoute;
});
app.UseSwaggerUI(opt =>
{
    opt.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
    opt.RoutePrefix = string.Empty;

});

app.Run();
