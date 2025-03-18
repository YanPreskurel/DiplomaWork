var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

var app = builder.Build();

// устанавливаем сопоставление маршрутов с контроллерами
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=}/{id?}");

app.MapGet("/", () => "Hello World!");

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();

app.Run();