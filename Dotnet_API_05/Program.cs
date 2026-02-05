using Dotnet_API_05.Data;
using Dotnet_API_05.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// ?? Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        path: "Logs/app-.log",
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 7
    )
    .CreateLogger();

builder.Host.UseSerilog();

// ?? Add services
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

var app = builder.Build();

// ?? Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseSerilogRequestLogging(); // ?? Logs HTTP requests

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
