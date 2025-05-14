using API.Mapping;
using DAL.Context;
using DAL.Repository;
using Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); //? если будет swagger
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();
app.UseHttpsRedirection(); //?
app.UseAuthorization(); //? для авторизации
app.MapControllers();
app.UseExceptionHandler("/error"); //? контроллер для ошибок
app.Run();