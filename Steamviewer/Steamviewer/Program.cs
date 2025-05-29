using Steamviewer.Components;
using Steamviewer.Components.Shared.Services;
using Steamviewer.Components.Shared.Services.Interfaces;
using Steamviewer.Services.Interfaces;
using Steamviewer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped<IWishlistService, WishlistService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();

builder.Services.AddHttpClient<SteamService>(client => 
{
    client.BaseAddress = new Uri("https://store.steampowered.com/api/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});


builder.Services.AddScoped<AppStateService>();

builder.Services.AddScoped<SteamService>();

builder.Services.AddHttpClient<IGameService, GameService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
});

builder.Services.AddHttpClient<IWishlistService, WishlistService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
});

builder.Services.AddHttpClient<IInventoryService, InventoryService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(Steamviewer.Client._Imports).Assembly);

app.Run();
