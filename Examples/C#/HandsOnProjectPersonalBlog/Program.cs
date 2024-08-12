using HandsOnProjectPersonalBlog.Attributes;
using HandsOnProjectPersonalBlog.Data;
using HandsOnProjectPersonalBlog.Interfaces;
using HandsOnProjectPersonalBlog.Repository;
using HandsOnProjectPersonalBlog.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var stringConnection = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<BlogContext>(x =>
{
    x.UseMySql(stringConnection, ServerVersion.AutoDetect(stringConnection));
});

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IAuthorizerService, AuthorizerService>();
builder.Services.AddScoped<ProtectorAttribute>();
builder.Services.AddLogging(c => c.AddConsole());

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

app.Run();
