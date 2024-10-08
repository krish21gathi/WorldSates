using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WorldAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Configure CORS

builder.Services.AddCors(Options =>
{
    Options.AddPolicy("Custompolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

#endregion

#region

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Custompolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
