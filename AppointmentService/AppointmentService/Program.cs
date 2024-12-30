using System.Text;
using AppointmentService.Contexts;
using AppointmentService.Filters;
using AppointmentService.Interfaces;
using AppointmentService.Models;
using AppointmentService.Repositories;
using AppointmentService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
internal class Program
{

    private static void Main(string[] args)
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
        #region AuthenticationFilter
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Keys:TokenKey"] ?? "")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });
        #endregion
        #region Contexts
        builder.Services.AddDbContext<AppointmentContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"));
        });
        #endregion
        #region Filters
        builder.Services.AddScoped<CustomExceptionFilter>();
        #endregion
        #region Mappers
        builder.Services.AddAutoMapper(typeof(Appointment));
        #endregion
        #region Repositories
        builder.Services.AddScoped<IRepository<int, Appointment>, AppointmentRepository>();
        #endregion
        #region Services
        builder.Services.AddScoped<IScheduleService, ScheduleService>();
        builder.Services.AddScoped<IUserManagementService, UserManagementService>();
        builder.Services.AddScoped<IAppointmentService, AppointmentServices>();
        builder.Services.AddScoped<IBillingService, BillingService>();
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

#region AuthenticationFilter

#endregion
#region Contexts

#endregion
#region Filters

#endregion
#region Mappers

#endregion
#region Repositories

#endregion
#region Services

#endregion
