using AutoMapper;
using HomeInsideOut.BusinessLayer.Config;
using HomeInsideOut.Common.Api;
using HomeInsideOut.Common.Api.Middleware;
using HomeInsideOut.DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace HomeInsideOut.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<HomeInsideOutContext>();
            builder.Services.AddOptions<ConnectionStrings>().Bind(builder.Configuration.GetSection("ConnectionStrings"));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            
            app.Run();
        }
    }
}