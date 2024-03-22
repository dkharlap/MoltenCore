using MoltenCore.Boilerplate;
using MoltenCore.Boilerplate.Interfaces;
using MoltenCore.Boilerplate.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();


//builder.Services.AddDbContext<BoilerplateDbContext>(options =>
//    options.UseSqlServer(connectionString, sqlOptions =>
//    {
//        sqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", schema);
//    }));



builder.Services.AddScoped<IBoilerplateRepository, BoilerplateRepository>();
builder.Services.AddScoped<IBoilerplateDomain, BoilerplateDomain>();


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
