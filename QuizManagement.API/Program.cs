using QuizManagement.API.Configuration;
using QuizManagement.API.Configurations;
using QuizManagement.API.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSqlServer(builder.Configuration);
builder.Services.AddDependency();
builder.Services.AddControllers();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//serilog config
//Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
//builder.Host.UseSerilog((ctx, lc) => lc
//    .ReadFrom.Configuration(ctx.Configuration));

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerAuthorization(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();
//app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseMiddleware<LoggerMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
app.MapControllers();

app.Run();
