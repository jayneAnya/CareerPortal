using Candidate_Application.Data;
using CareerPortal.Api.Interfaces;
using CareerPortal.Data;
using CareerPortal.Services;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
string databaseName = "CareerPortalDB";
string containerName = "CareerPortalApplication";

CosmosClient cosmosClient = new CosmosClient(connectionString);
Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);
Container container = await database.CreateContainerIfNotExistsAsync(containerName, "/id");

// Register repository and container
builder.Services.AddSingleton<Container>(container);
builder.Services.AddScoped<IUserResponse, CareerPortal.Services.UserResponse>();
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
