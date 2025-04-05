using API.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); //? если будет swagger
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();
app.UseHttpsRedirection(); //?
app.UseAuthorization(); //? для авторизации
app.MapControllers();
app.UseExceptionHandler("/error"); //? контроллер для ошибок
app.Run();