using CustomersWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace CustomersWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("CustomersWebAPIContext") ?? throw new InvalidOperationException("Connection string 'CustomersWebAPIContext' not found.");
            builder.Services.AddDbContext<CustomersWebAPIContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var CorsPolicy = "CorsPolicy";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicy,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200", "https://localhost:7087")
                               // Replace with your frontend's origin
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors(CorsPolicy);
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
