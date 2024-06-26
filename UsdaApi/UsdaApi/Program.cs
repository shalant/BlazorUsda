using MudBlazor.Services;
using UsdaApi.Components;
using UsdaApi.News;
using UsdaApi.UsdaInfo;
//using UsdaApiDisplay.Components;

var builder = WebApplication.CreateBuilder(args);
//var newsApiKey = builder.Configuration["News:ServiceApiKey"];

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddHttpClient();

builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IUsdaService, UsdaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
