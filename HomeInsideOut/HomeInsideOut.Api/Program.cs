using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Module.Identity.ServiceExtensions;
using Shared.Api.Middleware;
using Shared.BusinessLayer.Config;
using Shared.DataLayer.Data;
using Shared.Infrastructure.Extensions;
using System.Text;

namespace HomeInsideOut.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSharedInfrastructure(builder.Configuration);
            builder.Services.AddOptions<ConnectionStringsConfig>().Bind(builder.Configuration.GetSection(ConnectionStringsConfig.SectionPath));
            builder.Services.AddOptions<JwtConfig>().Bind(builder.Configuration.GetSection(JwtConfig.SectionPath));

            builder.Services.AddIdentityModule(builder.Configuration);

            var jwtOptions = builder.Configuration.GetSection(JwtConfig.SectionPath).Get<JwtConfig>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opts =>
                {
                    byte[] signingKeyBytes = Encoding.UTF8.GetBytes(jwtOptions.SigningKey);

                    opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                    };

                });

            builder.Services.AddDbContext<HomeInsideOutContext>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));


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
            app.UseCors("corsapp");

            app.MapControllers();

            app.Run();
        }
    }
}