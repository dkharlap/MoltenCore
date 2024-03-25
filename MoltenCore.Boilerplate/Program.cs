using Microsoft.EntityFrameworkCore;
using MoltenCore;
using MoltenCore.Boilerplate;
using MoltenCore.Boilerplate.Interfaces;
using MoltenCore.Boilerplate.Repository;
using MoltenCore.Interfaces;
using MoltenCore.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables(prefix: "MoltenCoreBoilerplate_");

// Add context
builder.Services.AddScoped<IUserContext, UserContext>();

// Add repository
var configRaw = builder.Configuration.GetSection("Repository");

var config = new RepositoryConfiguration(
    "Provider=SQLOLEDB.1;Password=boilerplate_reader_writer;Persist Security Info=True;User ID=boilerplate_reader_writer;Initial Catalog=IRDB;Data Source=DS",
    "boilerplate");
builder.Services.AddSingleton(config);

builder.Services.AddDbContext<BoilerplateDbContext>(options =>
    options.UseSqlServer(config.ConnectionString, sqlOptions =>
    {
        sqlOptions.MigrationsHistoryTable(config.MigrationHistoryTable, config.Schema);

        if (config.RetryMaxCount > 0)
        {
            sqlOptions.EnableRetryOnFailure(config.RetryMaxCount, TimeSpan.FromMilliseconds(config.RetryMaxDelay), config.RetryErrorNumbersToAdd);
        }
    }));


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
