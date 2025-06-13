using Microsoft.EntityFrameworkCore;
using Test2.DAL.context;
using Test2.Logic.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("RecordDatabase")
                       ?? throw new Exception("DeviceDatabase connection string is not found");

builder.Services.AddDbContext<RecordManiaContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddTransient<IRecordService, RecordService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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