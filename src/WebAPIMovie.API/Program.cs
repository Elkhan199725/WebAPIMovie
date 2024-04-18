using WebAPIMovie.Data;
using WebAPIMovie.Business;
using WebAPIMovie.Core;
using WebAPIMovie.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using FluentValidation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddValidatorsFromAssemblyContaining<GenreCreateDtoValidator>(); // This will scan the assembly for any FluentValidation validators and register them

builder.Services.AddDbContext<WebAPIMovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Apply migrations automatically
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<WebAPIMovieDbContext>();
        dbContext.Database.Migrate();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
