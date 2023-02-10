using Microsoft.EntityFrameworkCore;
using DI.Test.Data;
using DI.Test.Web.DataAccessLayer.User;
using DI.Test.Web.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = MsSqlDbContext.GetConnectionString();
builder.Services.AddDbContext<MsSqlDbContext>(x => x.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddScoped<IUserRepository<UserViewModel>, UserRepository>();

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
