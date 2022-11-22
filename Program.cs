using signalrdersleri.Hubs;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(
        policy =>
        {
            policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .SetIsOriginAllowed(t => true);
        });
});

builder.Services.AddControllers();
builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>("/ChatHub");
app.Run();
