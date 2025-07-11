using Microsoft.EntityFrameworkCore;
using DiscordApi.Contexts;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DiscordDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Apply database migrations in development
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<DiscordDbContext>();
        context.Database.EnsureCreated(); // For development only
        // context.Database.Migrate(); // For production
    }
}

app.UseCors();
app.UseRouting();
app.MapControllers();

app.Run();

