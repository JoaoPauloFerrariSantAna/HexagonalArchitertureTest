using Hexagonality2.Application.Domain.Interfaces;
using Hexagonality2.Application;
using Hexagonality2.Infrastructure;

namespace Hexagonality2;

public class Program
{
    private static void ConfigureHttpPipeline(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/openapi/v1.json", "API v1"));
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }

    private static void SubscribeDependencies(WebApplicationBuilder b)
    {
        b.Services.AddScoped<IStudentRepository, StudentRepository>();
        b.Services.AddScoped<IStudentService, StudentService>();
        b.Services.AddScoped<IDatabaseRepository, DatabaseRepository>();
        b.Services.AddScoped<IDatabaseService, DatabaseService>();
    }

    private static void AddToContainer(WebApplicationBuilder b)
    {
        // Learn more about config
        // uring OpenAPI at https://aka.ms/aspnet/openapi
        b.Services.AddControllers();
        b.Services.AddOpenApi();
        SubscribeDependencies(b);
    }

    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        WebApplication app = null;

        // Add services to the container.
        AddToContainer(builder);

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

        app = builder.Build();

        // Configure the HTTP request pipeline.
        ConfigureHttpPipeline(app);

        app.Run();
    }
}
