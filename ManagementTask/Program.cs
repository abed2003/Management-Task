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

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(builder =>
    builder.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());
}

// Use the CORS policy
//app.UseCors("AllowFrontend");
app.UseCors();


app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();