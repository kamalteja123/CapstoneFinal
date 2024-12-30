using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PatientRecordService.Contexts;
using PatientRecordService.Filters;
using PatientRecordService.Interfaces;
using PatientRecordService.Models;
using PatientRecordService.Repositories;
using PatientRecordService.Services;

namespace PatientRecordService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example:Breare <token>"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
            #region Filters
            builder.Services.AddScoped<CustomExceptionFilter>();
            #endregion
            #region Contexts
            builder.Services.AddDbContext<PatientRecordContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"));
            });
            #endregion
            #region Services
            builder.Services.AddScoped<IUserManagementService, UserManagementService>();
            builder.Services.AddScoped<ILabReportService, LabReportService>();
            builder.Services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();
            #endregion
            #region Repositories
            builder.Services.AddScoped<IRepository<int, MedicalHistory>, MedicalHistoryRepoistory>();
            builder.Services.AddScoped<IRepository<int, LabReport>, LabReportRepository>();
            #endregion
            #region Mappers
            builder.Services.AddAutoMapper(typeof(MedicalHistory));
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
