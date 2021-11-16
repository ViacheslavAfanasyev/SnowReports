using DataAccess.DataAccess;
using DataAccess.Repository;
using Logging;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

string CorsPolicy = "Cors_Policy";



if (!builder.Environment.IsDevelopment())
{
    var allowedOriginsObj = builder.Configuration.GetValue(typeof(String), "HostName");
    if (allowedOriginsObj != null)
    {
        builder.WebHost.UseUrls((string)allowedOriginsObj);
    }


    builder.Services.AddCors(options =>
    {
        var allowedOriginsObj = builder.Configuration.GetValue(typeof(String), "AllowedOrigins");

        if (allowedOriginsObj == null || (string)allowedOriginsObj==null)
        {
            allowedOriginsObj = "*";
        }

        options.AddPolicy(name: CorsPolicy,
                          builder =>
                          {
                              builder.WithOrigins(((string)allowedOriginsObj).Split(';'));
                          });
    });
}

// Add services to the container.

builder.Services.AddControllersWithViews();

string connectionString = string.Empty;
if (builder.Environment.IsDevelopment())
{
    connectionString = builder.Configuration.GetConnectionString("devSNReporting");
}
else
{
    connectionString = builder.Configuration.GetConnectionString("SNReporting");
}

builder.Services.AddDbContext<CasesContext>((options) =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<ISnowReportsRepository, SnowReportsRepository>();

//Register file logger
builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logs"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseCors(CorsPolicy);
}



app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
