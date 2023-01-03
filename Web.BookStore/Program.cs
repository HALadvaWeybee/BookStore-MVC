using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Web.BookStore.Data;
using Web.BookStore.Repositery;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreMVC")));

builder.Services.AddAutoMapper(typeof(Program));

#if DEBUG
builder.Services.AddRazorPages().AddRazorRuntimeCompilation().AddViewOptions(option =>
{
    option.HtmlHelperOptions.ClientValidationEnabled = true;
});
#endif

builder.Services.AddScoped<BookRepository, BookRepository>();
builder.Services.AddScoped<LanguageRepository, LanguageRepository>();

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

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllerRoute(name: "Default", pattern: "{controller=Home}/{action=Index}/{id?}");
    // tell our application for the use controller and action method
    // endpoint.MapDefaultControllerRoute();
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

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/himanshu", async context =>
    {
        await context.Response.WriteAsync("Hello Himanshu Ladva!");
    });
});


app.Run();
