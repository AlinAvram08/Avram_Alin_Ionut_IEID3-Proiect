using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Avram_Alin_Proiect.Data;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Avram_Alin_ProiectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Avram_Alin_ProiectContext") 
    ?? throw new InvalidOperationException("Connection string 'Avram_Alin_ProiectContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Avram_Alin_ProiectContext")
    ?? throw new InvalidOperationException("Connection string 'Avram_Alin_ProiectContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/AutoParts");
    options.Conventions.AuthorizeFolder("/Cars");
    options.Conventions.AuthorizeFolder("/Sales");
    options.Conventions.AuthorizeFolder("/Suppliers");
    options.Conventions.AuthorizeFolder("/Categories");
    options.Conventions.AllowAnonymousToPage("/AutoParts/Index");
    options.Conventions.AllowAnonymousToPage("/AutoParts/Details");
    options.Conventions.AuthorizeFolder("/Customers", "AdminPolicy");
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
