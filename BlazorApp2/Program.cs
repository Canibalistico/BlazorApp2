using BlazorApp2.Components;
using BlazorApp2.Data;
using BlazorApp2.Exceptions;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// refit service
builder.Services.AddRefitClient<IGuideLineApi>()
    .ConfigureHttpClient(
    c =>
    {
        c.BaseAddress = new Uri("https://localhost:7050/");
        c.Timeout = TimeSpan.FromSeconds(5);
    }

    );

//QuickGrid add
builder.Services.AddAntDesign();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

// Ilogger
builder.Services.AddLogging();
builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseExceptionHandler("/Error", createScopeForErrors: true);
app.UseExceptionHandler(_ => { });

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
