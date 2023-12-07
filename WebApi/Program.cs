using WebApi.Interfaces;
using WebApi.Services;
using Logging.Classes;
using Logging.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(q =>
    {
        q.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
            Title = "Assigment WebApi",
            Version = "v1",
            Description = "Web Api to validate a given vat number for a given country code"
        });
        q.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "WebApiDocumentation.xml"));
    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(q =>
    {
        q.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

builder.Services.AddScoped<IVatVerifier, VatVerifierService>();

builder.Services.AddSingleton<IGetFilePath, GetDefaultFilePath>();
builder.Services.AddSingleton<ILoggerGetDate, LoggerGetDate>();
builder.Services.AddScoped<ILoggerGetFile, LoggerGetFile>();
builder.Services.AddScoped<ILoggerLogFile, LoggerLogFile>();
//The services above are necessary for this one below to work.
//This one below is the one to use to get the file and log to it
builder.Services.AddScoped<ILoggerFacade, LoggerFacade>();

//builder.Services.AddLogging(q => q.AddLog2File(AppDomain.CurrentDomain.BaseDirectory));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
