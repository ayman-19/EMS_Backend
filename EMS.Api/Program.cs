using EMS.Api;
using EMS.Api.Middlewares;
using EMS.Application;
using EMS.Persistence;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string _cors = "EMs";
builder.Services.AddCors(options =>
{
    options.AddPolicy(_cors, policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder
    .Services.RegisterPersistenceDependancies(builder.Configuration)
    .RegisterApplicationDepenedncies()
    .RegisterMiddlewares();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(_cors);
app.UseMiddleware<ExceptionHandler>();
app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseAuthorization();

app.MapControllers();

app.Run();
