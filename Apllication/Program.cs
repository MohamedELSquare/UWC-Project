using BLL;
using BLL.Services;
using DAL.Context;
using DAL.Repositories.Abstractions;
using DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<RealTimeContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("UWC_RealTime")));
builder.Services.AddScoped<IPalletService, PalletService>();
builder.Services.AddScoped<IJobOrderService, JobOrderService>();
builder.Services.AddScoped<IJobOrderRepository, JobOrderRepository>();
builder.Services.AddScoped<IPalletRepository, PalletRepository>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISubCustomerService, SubCustomerService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IGateService, GateService>();

string cors = "_allowedOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(cors, builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<SignalService>();
builder.Services.AddHttpClient("SignalApi", client =>
{
    client.BaseAddress = new Uri("http://196.219.184.42:80/UWC/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}



app.UseAuthorization();

app.MapControllers();


app.UseCors(cors);
app.Run();
