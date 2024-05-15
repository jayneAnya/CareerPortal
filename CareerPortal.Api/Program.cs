using Candidate_Application.Data;
using CareerPortal.Api.Interfaces;
using CareerPortal.Api.Services;
using CareerPortal.Data;
using CareerPortal.Services;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("connection")!;
string databaseName = builder.Configuration.GetConnectionString("Database")!;
string containerName = builder.Configuration.GetConnectionString("ContainerName")!;

CosmosClient cosmosClient = new CosmosClient(connectionString);
Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);
Container container = await database.CreateContainerIfNotExistsAsync(containerName, "/id");

builder.Services.AddDbContext<CareerPortalContext>(options =>
    options.UseCosmos(connectionString, databaseName, containerName));

// Register repository and container
builder.Services.AddSingleton<Container>(container);
builder.Services.AddScoped<IUserResponse, CareerPortal.Services.UserResponse>();
builder.Services.AddScoped<IUserPersonalInformationQuestions, UserPersonalInformationQuestions>();
builder.Services.AddScoped<IRepository, Repository>();
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
