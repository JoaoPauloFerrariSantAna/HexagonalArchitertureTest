using Hexagonality2.Application.Domain.Interfaces;
using Hexagonality2.Application.Domain;

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
    }

    private static void AddToContainer(WebApplicationBuilder b)
    {
        // Learn more about config
        // uring OpenAPI at https://aka.ms/aspnet/openapi
        b.Services.AddControllers();
        SubscribeDependencies(b);
    }

    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        WebApplication app = null;

        // Add services to the container.
        AddToContainer(builder);

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        app = builder.Build();

        // Configure the HTTP request pipeline.
        ConfigureHttpPipeline(app);

        app.Run();
    }
}
