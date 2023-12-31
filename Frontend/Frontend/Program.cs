using Frontend.Client.Pages;
using Frontend.Components;
using Frontend.Components.Pages;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

builder.AddServiceDefaults();

builder.Services.AddHttpClient<Frontend.WeatherApiClient>(
    client => { client.BaseAddress = new Uri("http://api"); });

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// builder.Services.AddCascadingValue(x => new ThemeProvider.ThemeProviderValue());

var app = builder.Build();

app.MapDefaultEndpoints();

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
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();