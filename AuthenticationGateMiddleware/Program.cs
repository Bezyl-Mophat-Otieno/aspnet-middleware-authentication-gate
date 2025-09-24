using AuthenticationGateMiddleware.Extensions;
using AuthenticationGateMiddleware.Middlewares;
using Microsoft.OpenApi.Models;

namespace AuthenticationGateMiddleware;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddSwaggerGenWithAuthSupport();
        builder.Logging.ConfigureLogging();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI();
            app.UseSwagger();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseCustomAuth();
        app.MapControllers();
        app.Run();
    }
}