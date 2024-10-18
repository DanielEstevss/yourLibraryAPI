using Microsoft.EntityFrameworkCore;
using yourLibraryAPI.Context;
using yourLibraryAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Registrando a conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("ConnectionDb");

builder.Services.AddDbContext<yourLibraryDbContext>(options => options.UseSqlServer(connectionString));


// Registrando os repositórios para serem usados nos controllers
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();

builder.Services.AddScoped<ILivrosRepository, LivroRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
