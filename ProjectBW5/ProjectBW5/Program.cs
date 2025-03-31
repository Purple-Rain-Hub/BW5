using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectBW5.Data;
using ProjectBW5.Models;
using ProjectBW5.Settings;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<Jwt>(builder.Configuration.GetSection(nameof(Jwt)));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BW5DbContext>(options =>
    options.UseSqlServer(connectionString)
);

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.SignIn.RequireConfirmedAccount =
        builder.Configuration.GetSection("Identity").GetValue<bool>("RequireConfirmedAccount");

    options.Password.RequiredLength =
        builder.Configuration.GetSection("Identity").GetValue<int>("RequiredLength");

    options.Password.RequireDigit =
        builder.Configuration.GetSection("Identity").GetValue<bool>("RequireDigit");

    options.Password.RequireLowercase =
        builder.Configuration.GetSection("Identity").GetValue<bool>("RequireLowercase");

    options.Password.RequireNonAlphanumeric =
        builder.Configuration.GetSection("Identity").GetValue<bool>("RequireNonAlphanumeric");

    options.Password.RequireUppercase =
        builder.Configuration.GetSection("Identity").GetValue<bool>("RequireUppercase");
})
    .AddEntityFrameworkStores<BW5DbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetSection(nameof(Jwt)).GetValue<string>("Issuer"),
            ValidAudience = builder.Configuration.GetSection(nameof(Jwt)).GetValue<string>("Audience"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection(nameof(Jwt)).GetValue<string>("SecurityKey")))
        };
    });

builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<SignInManager<ApplicationUser>>();
builder.Services.AddScoped<RoleManager<ApplicationRole>>();

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
