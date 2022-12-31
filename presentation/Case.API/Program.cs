using Case.Database;
using Case.Domain.DTO;
using Case.Repository;
using Case.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(GeneralMapper).Assembly);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddCors(p => p.AddPolicy("corsApp", configurePolicy =>
{
    configurePolicy.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
}));
builder.Services.CaseDatabaseConnection(builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>());
builder.Services.CaseRepositories();
builder.Services.CaseServices();

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
app.UseCors("corsApp");

app.Run();