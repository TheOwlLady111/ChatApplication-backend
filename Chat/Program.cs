using Chat.Api.DataSeed;
using Chat.Api.Extensions;
using Chat.Api.Middlewares;
using Chat.BLL.Extensions;
using Chat.BLL.Hubs;
using Chat.DAL.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.Development.json", optional: false, reloadOnChange: true)
    .Build();

var settings = builder.AddAuthSettings();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuth(settings);
builder.Services.AddCorsExtension(configuration);
builder.Services.AddAutomapper();
builder.Services.AddValidation();
builder.Services.AddSignalR();
builder.Services.AddServices();
builder.Services.ConfigureDbContext(configuration);
builder.Services.AddRepositories();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ExceptionHandlerMiddleware>();
builder.Services.AddAuthentication();
builder.Services.AddSwaggerServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionHandlerMiddleware>();
await app.SeedDataAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

//Configure SignalR
app.MapControllers();
app.MapHub<ChatHub>("/chat").RequireCors("SignalRCorsPolicy");

app.Run();
