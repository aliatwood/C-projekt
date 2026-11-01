using FlashQuiz.Components;
using FlashQuiz;

var builder = WebApplication.CreateBuilder(args);

// Registrerar razor components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<ScoreService>();
var app = builder.Build();

// Konfigurerar hur applikationen hanterar fel och inkommande förfrågningar.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

// Gör statiska filer och Razor Components tillgängliga för applikationen.
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Startar webbapplikationen.
app.Run();
