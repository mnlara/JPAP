using System.Diagnostics;
using JPAP.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<ParserService>(); 
builder.Services.AddScoped<IParserService, ParserService>();
builder.Services.AddScoped<FilePathLocator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

new Thread(() =>
{
    try
    {
        var url = "http://localhost:5000";
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
    catch { }
}).Start();

//app.MapGet("/shutdown", (IHostApplicationLifetime lifetime) =>
//{
//    lifetime.StopApplication();
//    return Results.Ok();
//});

app.Run();
