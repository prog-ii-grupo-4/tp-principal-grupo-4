using Microsoft.EntityFrameworkCore;
using TP_Principal_G4.Entities;
using TP_Principal_G4.Repositories;
using TP_Principal_G4.Repositories.Contracts;

namespace TP_Principal_G4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<TpPrincipalG4Context>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("TpPrincipalDb"));
                }
            );

            builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();

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