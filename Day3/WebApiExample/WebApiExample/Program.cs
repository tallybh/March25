using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApiExample.Contracts;
using WebApiExample.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductsRepository, ProductRepository>();
builder.Services.AddScoped<IFiles, FilesService>();
builder.Services.AddScoped<IBlogRepository, BlogsRepository>();
builder.Services.AddScoped<IPostsRepository, PostsRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

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

app.UseSerilogRequestLogging();

app.Run();
