
using DAL.Context;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using PlantsBAL.Services;

namespace FlowersApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<Plantscontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));

            });
			builder.Services.AddScoped(typeof(IbaseRepo<>), typeof(Generic<>));
			builder.Services.AddScoped(typeof(IBaseservice<>), typeof(Genericeservice<>));
			builder.Services.AddCors(options =>
            {
                options.AddPolicy("shereen", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseCors("shereen");

            app.MapControllers();

            app.Run();
        }
    }
}
