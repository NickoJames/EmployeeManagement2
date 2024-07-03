using Microsoft.OpenApi.Models;
using RecordManagement.Application;

using RecordManagement.Api;



var builder = WebApplication.CreateBuilder(args);
{
    // Configure services
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        ;
    builder.Services.AddControllers();
    }



// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Record Management API", Version = "v1" });
});

var app = builder.Build();

// Configure middleware
//app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Record Management API V1");
});

app.UseAuthorization();

// Configure endpoints
app.MapControllers();

app.Run();