var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();




//Build işmemi oluşur ve middleware'ler eklenir
var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
