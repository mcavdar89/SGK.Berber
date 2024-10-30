using Infrastructure.DAL.Abstracts;
using Infrastructure.DAL.Concretes;
using Microsoft.EntityFrameworkCore;
using SGK.Berber.BL.Abstracts;
using SGK.Berber.BL.Concretes;
using SGK.Berber.DAL.Abstracts;
using SGK.Berber.DAL.Concretes;
using SGK.Berber.DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region Depend

builder.Services.AddDbContext<BerberDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("BerberConnectionString"));
});
builder.Services.AddScoped<IBerberRepository, BerberRepository>();
builder.Services.AddScoped<IRandevuService, RandevuService>();


//builder.Services.AddTransient<IBaseRepository, BaseRepository>();
//builder.Services.AddScoped<IBaseRepository, BaseRepository>();
//builder.Services.AddSingleton<IBaseRepository, BaseRepository>();
#endregion


//Build işmemi oluşur ve middleware'ler eklenir
var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
