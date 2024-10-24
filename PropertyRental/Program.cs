using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using PropertyRental.Domain.Entities.User;
using PropertyRental.Infrastructure.Data;
using System.Globalization;
using AutoMapper;
using PropertyRental.Application.Mapping;
using PropertyRental.Application.Services;
using System.Data;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PropertyRental.Application.Hubs;
var builder = WebApplication.CreateBuilder(args);
var cultures = new[]
{
    new CultureInfo("en-US"),
    // Add other cultures if necessary
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"), b => b.MigrationsAssembly("PropertyRental.Infrastructure")));
builder.Services.AddSignalR();
builder.Services.AddIdentity<User, Role>(options =>
{
    {
        // Password settings
        options.Password.RequireDigit = true;
        // Lockout settings
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;

        // User settings
        options.User.RequireUniqueEmail = true;

        // Sign-in settings
        options.SignIn.RequireConfirmedEmail = true;
    }
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = builder.Configuration["Jwt:Issuer"],
           ValidAudience = builder.Configuration["Jwt:Audience"],
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
       };
   });

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<PropertyAppService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<ChatService>();
builder.Services.AddScoped<PayPalService>();
builder.Services.AddScoped<LeaseAgreementAppService>();
builder.Services.AddScoped<UserAppService>();
builder.Services.AddScoped<RoleService>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Owner", policy => policy.RequireRole("Owner"));
    options.AddPolicy("Tenant", policy => policy.RequireRole("Tenant"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Enable authentication
app.UseAuthorization();  // Enable authorization

app.MapControllers();
app.MapHub<ChatHub>("/chatHub");
app.Run();
