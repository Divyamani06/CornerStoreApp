using CornerStore.API.AddDependencyInjectionServices;
using CornerStore.API.Authenticaion;
using CornerStore.API.Context;
using CornerStore.API.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.APIDependencyInjections();
        builder.Services.AddControllers();
        //Database Connection
        builder.Services.AddDbContext<ApplicationDbContext>(context => context.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));
        // for mapping
        builder.Services.AddAutoMapper(typeof(MappingProflie));
        // Adding Authentication
        var tokenKey = builder.Configuration.GetSection("JwtToken");
        builder.Services.Configure<JwtToken>(tokenKey);
        var authKey = builder.Configuration.GetValue<string>("JwtToken:Key");
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = true;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        builder.Services.AddAuthorizationBuilder()
            .AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"))
            .AddPolicy("UserPolicy", policy => policy.RequireRole("User"));

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
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}