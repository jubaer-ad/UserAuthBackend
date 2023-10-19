using backend.DB;
using backend.Repositories;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<IUserRepositories, UserRepositories>();

var theOrigins = "_theOrigins";
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy(theOrigins, policy =>
    {
        var origins = configuration.GetSection("AllowedOrigins").Value.ToString().Split(";");
        policy.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

var app = builder.Build();
app.UseCors(theOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
