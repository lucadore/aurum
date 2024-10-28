using AurumServer.Components;
using AurumServer.Services;

var builder = WebApplication.CreateBuilder(args);

// 기본 로깅 구성 추가 (콘솔 로그 포함)
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddSingleton<VoteService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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
