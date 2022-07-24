using Microsoft.EntityFrameworkCore;
using RegulationAssessment.Common;
using RegulationAssessment.DataAccess.EntityFramework.Models;
using RegulationAssessment.DataAccess.EntityFramework.UnitOfWork.Implement;
using RegulationAssessment.DataAccess.EntityFramework.UnitOfWork.Interface;
using RegulationAssessment.Logic.UnitOfWork.Implement;
using RegulationAssessment.Logic.UnitOfWork.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// connection resolver
ConnectionResolver.RAConnection = builder.Configuration.GetConnectionString("RAConnection");
ConnectionResolver.IsProduction = bool.Parse(builder.Configuration.GetConnectionString("IsProduction"));
ConnectionResolver.FrontendUrl = builder.Configuration.GetConnectionString("FrontendUrl");

// data access service
builder.Services.AddDbContext<RAContext>(options =>
{
    options.UseNpgsql(ConnectionResolver.RAConnection)
            .EnableSensitiveDataLogging()
            .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));
});

// Add unit of work service 
builder.Services.AddScoped<IEntityUnitOfWork, EntityUnitOfWork>();
builder.Services.AddScoped<ILogicUnitOfWork, LogicUnitOfWork>();

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

