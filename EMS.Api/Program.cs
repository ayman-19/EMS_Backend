using EMS.Api;
using EMS.Api.Middlewares;
using EMS.Application;
using EMS.Persistence;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder
    .Services.RegisterPersistenceDependancies(builder.Configuration)
    .RegisterApplicationDepenedncies()
    .RegisterMiddlewares();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandler>();
app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseAuthorization();

app.MapControllers();

app.Run();
