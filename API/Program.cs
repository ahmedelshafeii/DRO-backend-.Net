using API.MapHelper;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapHelper));


builder.Services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<ICenterRepository, CenterRepository>();


builder.Services.AddDbContext<HospitalContext>(o=>o.UseSqlServer(
    builder.Configuration.GetConnectionString("Default")
    ));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars =0;
    options.Password.RequireLowercase=false;
    options.Password.RequireUppercase = false;
    options.User.RequireUniqueEmail = true;
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedAccount = false;

}).AddEntityFrameworkStores<HospitalContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Doctor",policy=>policy.RequireClaim(ClaimTypes.Role,"Doctor"));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Default";
    options.DefaultChallengeScheme = "Default";
}).AddJwtBearer("Default", o =>
{
    var key = builder.Configuration.GetValue<string>("Key");
    var keyInBytes = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

    o.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = keyInBytes,
        ValidateIssuer = false,
        ValidateAudience = false,
    };

});

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
