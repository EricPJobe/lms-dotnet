using lms_server.database;
using lms_server.Interfaces;
using lms_server.Repositories;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")); 
}); 

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddScoped<IUnitRepository, UnitRepository>(); 
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; 
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

