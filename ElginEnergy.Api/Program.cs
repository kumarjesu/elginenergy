using ElginEnergy.Api.DatabaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Data base Context - Dependency Injection  */
/* ========================================= */
var dbHost = "localhost";
var dbName = "dms_orderbooks";
var dbUser = "sa";
var dbPassword = "Jazlyn09";
var dbTrust = true;
var dbMulti = true;
var connectionString = $"Server={dbHost};Database={dbName};User ID={dbUser};Password={dbPassword};MultiSubnetFailover={dbMulti};TrustServerCertificate={dbTrust};";
/* ==================================================================================================================================================================== */

builder.Services.AddDbContext<OrderBooksDbContext>(opt => opt.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
