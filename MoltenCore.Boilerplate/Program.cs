using MoltenCore;
using MoltenCore.Boilerplate.Domain;
using MoltenCore.Boilerplate.Domain.Interfaces;
using MoltenCore.Boilerplate.Repository;
using MoltenCore.Boilerplate.Repository.Interfaces;
using MoltenCore.Extensions;
using MoltenCore.Interfaces;
using MoltenCore.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables("BOILERPLATE");

// Add context
builder.Services.AddScoped<IUserContext, UserContext>();

// Add repository

var repositoryConfigurationSection = builder.Configuration.GetSection("REPOSITORY");

var repositoryConfiguration = new RepositoryConfiguration(repositoryConfigurationSection);
builder.Services.AddSqlServerDbContext<BoilerplateDbContext>(repositoryConfiguration);

var repositoryConfigurationReadOnly = new RepositoryConfiguration(repositoryConfigurationSection, true);
builder.Services.AddSqlServerDbContext<BoilerplateReadOnlyDbContext>(repositoryConfigurationReadOnly);

builder.Services.AddScoped<IBoilerplateRepository, BoilerplateRepository>();

// Configure domain
builder.Services.AddScoped<IBoilerplateDomain, BoilerplateDomain>();

// Add API services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/healthz");

app.Run();
