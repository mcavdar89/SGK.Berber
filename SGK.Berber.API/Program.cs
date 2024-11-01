﻿using Infrastructure.DAL.Abstracts;
using Infrastructure.DAL.Concretes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SGK.Berber.BL.Abstracts;
using SGK.Berber.BL.Concretes;
using SGK.Berber.DAL.Abstracts;
using SGK.Berber.DAL.Concretes;
using SGK.Berber.DAL.Contexts;
using SGK.Berber.Model.Profiles;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation    
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Ulusal Ajans Web Api",
        Description = "Authentication and Authorization in ASP.NET CORE 7 with JWT and Swagger",
    });
    // To Enable authorization using Swagger (JWT)    
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Token Bilgisini Giriniz: \r\n\r\nÖrnek Kullanım: \r\nBearer eyJhbGciOiJIUzI1NiIsInR5...",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecurityKey"]))
        };
    });




#region Depend

builder.Services.AddDbContext<BerberDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("BerberConnectionString"));
});
builder.Services.AddScoped<IBerberRepository, BerberRepository>();

builder.Services.AddScoped<IRandevuService, RandevuService>();
builder.Services.AddScoped<IPersonelService, PersonelService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<ICalismaSaatleriService, CalismaSaatleriService>();

builder.Services.AddAutoMapper(typeof(BerberProfile));

//builder.Services.AddTransient<IBaseRepository, BaseRepository>();
//builder.Services.AddScoped<IBaseRepository, BaseRepository>();
//builder.Services.AddSingleton<IBaseRepository, BaseRepository>();
#endregion


//Build işmemi oluşur ve middleware'ler eklenir
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
