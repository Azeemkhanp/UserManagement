using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManagement.DBManagementFiles;
using UserManagement.Interface;
using UserManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(Program).Assembly);

// OpenAPI / Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services lifetime
builder.Services.AddScoped<IUser, UserRepo>();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
    });
}

app.UseHttpsRedirection();

// 🛑 IMPORTANT: Static files MUST come BEFORE Auth and Routing
app.UseDefaultFiles(); // Looks for index.html in wwwroot
app.UseStaticFiles();  // Serves the index.html and other static assets

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// 🎯 THE FIX: Tell the root URL to redirect to Swagger immediately
// (If you don't have an index.html, this will prevent the 404 error)
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();