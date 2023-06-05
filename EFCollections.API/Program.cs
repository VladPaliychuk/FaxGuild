using EFCollections.DAL.Data;
using EFCollections.DAL.Interfaces.Repositories;
using EFCollections.DAL.Data.Repositories;
using EFCollections.BLL.Interfaces;
using EFCollections.BLL.Services;
using Microsoft.EntityFrameworkCore;
using EFCollections.BLL.Configurations;
using EFCollections.BLL.Factories;
using FluentValidation;
using EFCollections.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<CollectionContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
    options.UseSqlServer(connectionString);
});

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
builder.Services.AddScoped<ICollectionPostRepository, CollectionPostRepository>();
builder.Services.AddScoped<ISavedRepository, SavedRepository>();
builder.Services.AddScoped<IStorageRepository, StorageRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<ISavedService, SavedService>();
builder.Services.AddScoped<ICollectionPostService, CollectionPostService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddTransient<JwtTokenConfiguration>();
builder.Services.AddTransient<IJwtSecurityTokenFactory, JwtSecurityTokenFactory>();

builder.Services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();

/*builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
})
                    .AddFluentValidation(configuration =>
                    {
                        configuration.RegisterValidatorsFromAssemblies(
                            AppDomain.CurrentDomain.GetAssemblies());
                    });*/
builder.Services.AddAuthentication();
builder.Services.AddIdentityCore<User>()
                    .AddRoles<IdentityRole<int>>()
                    .AddSignInManager<SignInManager<User>>()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<CollectionContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["JwtSecurityKey"])),
                ClockSkew = TimeSpan.Zero,
            };
        });
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EFCollection.API",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                                    Enter 'Bearer' [space] and then your token in the
                                    text input below. Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new List<string>()
                    }
                });
});

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
