using Albums.Business.Services;
using Albums.Domain.Contracts;
using Albums.Infrastucture.Data.Repositories;
using Albums.Infrastucture.interfaces;
using Albums.Infrastucture.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAlbumsService, AlbumsService>();
builder.Services.AddScoped<IPhotosService, PhotosService>();
builder.Services.AddScoped<IAlbumsRepository, AlbumsRepository>();
builder.Services.AddScoped<IPhotosRepository, PhotosRepository>();
builder.Services.AddScoped<IPhotosDbReposiory, PhotosDbRepository>();
builder.Services.AddScoped<IAlbumsDbRepository, AlbumsDbRepository>();

// Create connection string file
string path = Directory.GetCurrentDirectory() + "ConnectionString.txt";

// This text is added only once to the file.
if (!File.Exists(path))
{
    // Create a file to write to.
    string createText = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AlbumPhotos;"
                        + "Integrated Security=true;" + Environment.NewLine;
    File.WriteAllText(path, createText, Encoding.UTF8);
}

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
