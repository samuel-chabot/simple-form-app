using Microsoft.EntityFrameworkCore;
using SimpleFormApp.Database;
using SimpleFormApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddTransient<IRequestFormService, RequestFormService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


using (var servicescope = app.Services.CreateScope())
{
    var logger = servicescope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    while (true)
    {
        try
        {
            var db = servicescope.ServiceProvider.GetRequiredService<ApplicationContext>();
            db.Database.Migrate();
            logger.LogInformation("Migrations applied successfully");
            break;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to migrate");
        }

        await Task.Delay(2000);
    }
}

app.Run();

