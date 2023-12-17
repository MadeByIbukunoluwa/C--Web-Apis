global using Rpg_Api.Models;

global using Rpg_Api.Services.CharacterService;

global using Rpg_Api.Dtos.Character;

global using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Now it knows to use the character service class whenever the controller wants to check the ICharacterService
builder.Services.AddScoped<ICharacterService, CharacterService>();
//AddTransient provides a new instance to every controller and to every service
//Add singleton uses one instance that is used for every request 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();   


app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();


