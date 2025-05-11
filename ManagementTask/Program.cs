using ManagementTask.DBCon;
using ManagementTask.Interface;
using ManagementTask.Reposetry;
using ManagementTask.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUsers, UsersRepo>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ITask, TaskRepo>();
builder.Services.AddScoped<TaskService>();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBC>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("task")));
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
