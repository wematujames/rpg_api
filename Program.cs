global using dnet_rpg.Models;
global using dnet_rpg.v1.Services.CharacterService;
global using dnet_rpg.v1.DTOs.Character;
global using Microsoft.EntityFrameworkCore;
global using AutoMapper;
global using dnet_rpg.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")
    )
);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICharacterService, CharacterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.UseAuthorization();
app.MapControllers();
 
app.Run();

