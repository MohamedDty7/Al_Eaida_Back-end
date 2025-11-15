using System.Text;
using Al_Eaida_Domin.Modules;
using Al_Eaida_Domin.Shared;
using AL_Eaida_Infrastructure__Layer;
using AL_Eaida_Infrastructure__Layer.Data;
using EL_Eaida_Applcation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration; // Add this namespace to resolve IConfiguration


var builder = WebApplication.CreateBuilder(args);

// 1. Configure JwtSettings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<JwtSettings>>().Value);

// 2. Configure DbContext
builder.Services.AddDbContext<AppDBcontext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        m => m.MigrationsAssembly(typeof(AppDBcontext).Assembly.FullName));
});

// 3. Add Identity + EF
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    
    // User settings - Allow Arabic characters and special symbols
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ءابتثجحخدذرزسشصضطظعغفقكلمنهوي";
    options.User.RequireUniqueEmail = true;
    
    // SignIn settings
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
})
.AddEntityFrameworkStores<AppDBcontext>()
.AddDefaultTokenProviders();

// 4. JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
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
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
             Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    }; ;
});

builder.Services.AddAuthorization();

// 5. Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// 6. Add Services (Application + Infrastructure)
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

// 7. CORS - Frontend policy with credentials
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:4200",
                "http://localhost:57957",
                "http://localhost:61460"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// 8. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            }, new string[] {}
        }
    });
});

// 9. Add SignalR
builder.Services.AddSignalR();
builder.Services.AddScoped<Al_Eaida_Domin.Interface.INotificationRepository, AL_Eaida_Infrastructure__Layer.Repositery.NotificationRepository.NotificationRepository>();
builder.Services.AddScoped<EL_Eaida_Applcation.InterFaceServices.INotificationService, WebApplication1.Services.NotificationService>();

builder.Services.AddControllers();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply CORS before auth and endpoints
app.UseCors("Frontend");

app.UseAuthentication();
app.UseAuthorization();

// Map endpoints with CORS requirement
app.MapControllers().RequireCors("Frontend");
app.MapHub<WebApplication1.Hubs.NotificationHub>("/notificationHub").RequireCors("Frontend");

app.Run();
