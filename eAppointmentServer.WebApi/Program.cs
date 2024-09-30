using DefaultCorsPolicyNugetPackage;
using eAppointmentServer.Application;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Infrastructure;
using eAppointmentServer.WebApi;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultCors();


builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

Helper.CreateUserAsync(app).Wait();//Oluşturduğumuz helper classını tanımladık.Asenkron metot olduğu için Wait yazdık.

    app.Run();
