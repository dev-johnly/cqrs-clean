using cqrs_clean.Application.Common;
using cqrs_clean.Infrastructure;

using MediatR;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
//    c =>
//{
//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Description = "Enter JWT token",
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        Scheme = "bearer"
//    });

//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "Bearer"
//                }
//            },
//            new string[] { }
//        }
//    });
//}
);
builder.Services.AddControllers();

var app = builder.Build();

// Enable Swagger only in Development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Access Swagger UI at root URL
    });
}


app.UseAuthorization();
app.MapControllers();
app.Run();
