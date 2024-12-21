using Albums.Business.Services;
using Albums.Domain.Contracts;
using Albums.Infrastucture.interfaces;
using Albums.Infrastucture.Repository;

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
