using Microsoft.EntityFrameworkCore;
using SMS_Data.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContextDB>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString")));

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", builder =>
    {
        builder.WithOrigins("*")
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    app.UseCors("AllowOrigin");
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
