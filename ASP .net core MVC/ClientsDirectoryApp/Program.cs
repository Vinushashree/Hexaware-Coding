var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ✅ Important: Set default route to ClientController > ShowAllClientDetails
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=ShowAllClientDetails}/{id?}");

app.Run();
