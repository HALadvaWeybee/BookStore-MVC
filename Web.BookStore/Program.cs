using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Web.BookStore.Data;
using Web.BookStore.Models;
using Web.BookStore.Repositery;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreMVC")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<BookStoreContext>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.Configure<IdentityOptions>(option =>
{
    option.Password.RequiredLength = 5;
    option.Password.RequiredUniqueChars = 0;
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireNonAlphanumeric = false;
});

#if DEBUG
builder.Services.AddRazorPages().AddRazorRuntimeCompilation().AddViewOptions(option =>
{
    option.HtmlHelperOptions.ClientValidationEnabled = true;
});
#endif

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.Configure<NewBookAlertConfig>(builder.Configuration.GetSection("NewBookAlert"));

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

/*app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello i am first middleware");
    await next();
    await context.Response.WriteAsync("Hello i am first middleware response");
});
app.Use(async (context, next) =>
{   
    await context.Response.WriteAsync("Hello i am second middleware");
    await next();
    await context.Response.WriteAsync("Hello i am second middleware response");
});
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello i am third middleware");
    await next();
    await context.Response.WriteAsync("Hello i am third middleware response");
});*/

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseRouting();
app.UseStaticFiles();

// for use of another folder as static files container
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
    RequestPath = "/MyStaticFiles"
});


app.UseEndpoints(endpoints =>
{
    endpoints.Map("/himanshu", async context =>
    {
        await context.Response.WriteAsync("Hello Himanshu Ladva!");
    });
});

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoint =>
{
    //endpoint.MapControllerRoute(name: "Default", pattern: "{controller=Home}/{action=Index}/{id?}");

    //endpoint.MapControllerRoute(name: "About-us", pattern: "about-us", defaults: new { controller = "Home", action = "AboutUs" });
    // tell our application for the use controller and action method
    //endpoint.MapDefaultControllerRoute();

    endpoint.MapControllers();
    /*endpoint.MapGet("/", async context =>
    {
       
        *//*if (app.Environment.IsDevelopment())
            await context.Response.WriteAsync("hello i am from development");
        else if (app.Environment.IsProduction())
            await context.Response.WriteAsync("hello i am from production");
        else if (app.Environment.IsStaging())
            await context.Response.WriteAsync("hello i am from staging");
        // custom environment
        else if (app.Environment.IsEnvironment("Developing"))
            await context.Response.WriteAsync("hello i am from Developing");

        await context.Response.WriteAsync(app.Environment.EnvironmentName);*//*
    });*/
});

app.Run();
