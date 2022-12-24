using FootBall.API.Interfaces;
using FootBall.API.Services;
using FootBall.API.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PlayerContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Football_db")));
builder.Services.AddDbContext<RefereeContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Football_db")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPlayerService, PlayerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  

app.UseAuthorization();

app.MapControllers();

app.Run();
