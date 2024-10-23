using Data.Model.Implements;
using Data.Model.Interfaces;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Servicio.Model.Implements;
using Servicio.Model.Interfaces;

namespace WebA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Configuracion Cords
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        //policy.WithOrigins("http://localhost:4200")
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            // Configura DbContext con SQL Server
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbfaultConnection")));

            //Configuiracion de Data I,S
            builder.Services.AddScoped<IPersonajeData, PersonajeData>();

            //Configuracion de Serviceess I,S
            builder.Services.AddScoped<IPersonajeService, PersonajeService>();

            // Add services to the container.
            builder.Services.AddControllers();


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

            app.UseCors("AllowSpecificOrigin");


            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}