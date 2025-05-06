using BLL;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using UHFAPP;
using UWC.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Add>();
builder.Services.AddSingleton<SignalService>();
builder.Services.AddDbContext<RealTimeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UWC_RealTime")));
builder.Services.AddHostedService<ContinuousTaskService>();
builder.Services.AddHttpClient("SignalApi", client =>
{
    client.BaseAddress = new Uri("http://196.219.184.42:80/UWC/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();
