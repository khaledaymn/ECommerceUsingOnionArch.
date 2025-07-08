#region Usings
using ECommerce.Domain.Data;
using ECommerce.Domain.Extend;
using ECommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
#endregion

#region Builder Configuration
var builder = WebApplication.CreateBuilder(args);
#endregion

#region Services Configration 

#region Connection String Configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

#region API Configuration
// Add services to the container.

builder.Services.AddControllers();
#endregion


#region OpenAPI Configuration
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#endregion


#region CORS Configuration
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAllOrigins",
//        builder => builder.AllowAnyOrigin()
//                          .AllowAnyMethod()
//                          .AllowAnyHeader());
//});
#endregion


#region Identity Configration

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
}).AddEntityFrameworkStores<ApplicationDbContext>()
 .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

#endregion


#region Swagger Configration

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "E-Commerce",
        Description = "API documentation for ECommerce",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Khaled Ayman",
            Email = "khaled654ayman0@gmail.com"
        }
        //License = new OpenApiLicense
        //{
        //    Name = "Not Found any license",
        //    Url = new Uri("https://example.com/license")
        //}
    });

    // JWT Authentication setup
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });

    // Enable XML comments if available
    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});

#endregion


#endregion

#region Build the application
var app = builder.Build();

#endregion

#region Environment Configuration
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var prefix = string.IsNullOrEmpty(options.RoutePrefix) ? "." : "..";
    options.SwaggerEndpoint($"{prefix}/swagger/v1/swagger.json", "Shiping Management System v1");
    options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    options.DisplayRequestDuration();
});

#endregion

#region Middleware Configuration


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion