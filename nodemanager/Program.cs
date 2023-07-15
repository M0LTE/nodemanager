using nodemanager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IModemService, LinuxModemService>();
builder.Services.AddSingleton<BpqManagerService>();

if (Environment.OSVersion.Platform == PlatformID.Win32NT)
{
    builder.Services.AddTransient<IBpqStateService, DevBpqStateService>();
}
else
{
    builder.Services.AddTransient<IBpqStateService, LinuxBpqStateService>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
