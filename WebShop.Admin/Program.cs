using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebShop.Data.Implementation;
using WebShop.Data.Models;
using WebShop.Data;
using WebShop.Service;

var builder = WebApplication.CreateBuilder(args);

//-------------------------------------------------------------------------------Adding Session och coockes
builder.Services.AddMvc();
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(15); });

//------------------------------------------------------------------------------DB Connection injection and Identity BD 

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddCors(p => p.AddPolicy("restPolicy", builder =>
{
    builder.WithOrigins("*")
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

//--------------------------------------------------------------------------------Scoping och injection 
// här kan vi skapa Scop i våra 
//  builder.Services.AddScoped < interface , class >();
builder.Services.AddScoped<ICategoryRepository, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductService>();
builder.Services.AddScoped<IOrderRepository, OrderService>();
builder.Services.AddScoped<IOrderItemsRepository, OrderItemsService>();
builder.Services.AddScoped<IAccessTokenRepository, AccessTokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("restPolicy");

//--------------------------------------------------------------------------bör läggas till Authenticatin Use efter Authentication !! 
app.UseAuthentication();
app.UseAuthorization();

//--------------------------------------------------------------------------navigation 

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=dashboard}/{action=Index}/{id?}");

app.Run();