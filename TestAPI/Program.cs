using Microsoft.Extensions.Configuration;
using RainfallAPI.Controllers;
using RainfallAPI.Services;

namespace RainfallAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
            builder.Services.AddTransient<ProcessAPIResponse>();
            builder.Services.AddHttpClient<ProcessAPIResponse>(client =>
            {
                var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();
                client.BaseAddress = new Uri(apiSettings.BaseUri);
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}