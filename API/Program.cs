using API.Mapping;
using API.Middleware;
using DAL.Context;
using DAL.Repository;
using Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

//app.UseHttpsRedirection(); //?
app.UseRouting();
app.UseAuthorization(); //? для авторизации
app.MapControllers();

app.Run();
