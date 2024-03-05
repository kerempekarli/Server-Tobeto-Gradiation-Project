using Autofac.Core;
using Business;
using Business.DTOs.Response.Course;
using Core.Aspects.ActionFilters;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.Utilities.JWT;
using DataAccess;
using MediatR;
using Serilog;
using StackExchange.Redis;
using System.Reflection;





var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessServices();


builder.Services.AddScoped<Serilog.ILogger>(provider => new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("Logs/myapp.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger());
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("Logs/myapp.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddScoped<LogActionAttribute>();

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis-16350.c267.us-east-1-4.ec2.cloud.redislabs.com:16350,password=6CkWVBIu5cVuXRa7sU2LLeXCZZv389yY");
IDatabase database = redis.GetDatabase();
database.StringSet("foo", "bar");
Console.WriteLine(database.StringGet("foo")); // prints bar

//Services
builder.Services.AddSingleton<RedisService>();
builder.Services.AddScoped<RedisCacheAttribute>();
builder.Services.AddScoped<RemoveCacheAttribute>();
builder.Services.AddScoped<TransactionAttribute>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


var config = builder.Configuration;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Logging.ClearProviders();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<IRequestHandler<GetListCourseByDynamicQuery, CourseListModel>, GetListCourseByDynamicQuery.GetListCourseByDynamicQueryHandler>();


builder.Services.AddScoped<LogActionAttribute>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.ConfigureCustomExceptionMiddleware();
}
app.UseJwtDecoderMiddleware();
app.UseCors("MyCorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


Log.Information("Application starting...");


app.Run();
