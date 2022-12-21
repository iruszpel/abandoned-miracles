using System.Globalization;
using System.Text;
using System.Text.Json;
using AbandonedMiracle.Api.DataAccess;
using AbandonedMiracle.Api.Entities.Identity;
using AbandonedMiracle.Api.Exceptions;
using AbandonedMiracle.Api.Helpers;
using AbandonedMiracle.Api.Services;
using AbandonedMiracle.Api.Settings;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var jwtSettings = new JwtSettings();
builder.Configuration.GetSection(JwtSettings.Section).Bind(jwtSettings);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.Section));

builder.Services.AddControllers()
    .AddJsonOptions(opt => { opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.CustomSchemaIds(x => x.FullName!.Replace("+", "."));
});

builder.Services.AddIdentity<AmUser, AmRole>()
    .AddEntityFrameworkStores<AmDbContext>();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequiredLength = 8;
    opt.Password.RequiredUniqueChars = 0;
    opt.User.RequireUniqueEmail = true;
});

builder.Services.AddDbContext<AmDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services
    .AddAuthentication(opt =>
    {
        opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
    };
});

builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.RegisterValidators();

builder.Services.AddScoped<IJwtService, JwtService>();

ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en-us");

var app = builder.Build();

app.UseMiddleware<RestExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();