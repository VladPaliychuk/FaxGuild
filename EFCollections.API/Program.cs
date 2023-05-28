using EFCollections.DAL.Data;
using EFCollections.DAL.Interfaces.Repositories;
using EFCollections.DAL.Data.Repositories;
using EFCollections.DAL.Entities;
using EFCollections.BLL.Interfaces;
using EFCollections.BLL.Services;
using AutoMapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MyEventsEntityFrameworkDb.EFRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CollectionContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
});

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
builder.Services.AddScoped<ICollectionPostRepository, CollectionPostRepository>();
builder.Services.AddScoped<ISavedRepository, SavedRepository>();
builder.Services.AddScoped<IStorageRepository, StorageRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<ISavedService, SavedService>();

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
