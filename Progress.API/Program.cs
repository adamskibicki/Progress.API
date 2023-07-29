using Microsoft.EntityFrameworkCore;
using Progress.API;
using Progress.Application.Persistence;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.RegisterServices(builder.Services);

var app = builder.Build();
startup.SetupMiddleware(app, builder.Environment);

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();
    
    dbContext.Database.Migrate();
}

app.Run();
