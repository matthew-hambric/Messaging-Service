using Dynamics.MessagingService;
using Dynamics.MessagingService.Abtractions.Services;
using Dynamics.MessagingService.Persistence.EntityFramework;
using Dynamics.MessagingService.Akka;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCoreServices_TESTING();
builder.Services.UseEntityFrameworkInMemoryDatabase_TESTING();

builder.Services.AddCustomAkkaServices();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Configure application pipeline.

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else{
    //app.UseHttpsRedirection();
}

app.UseAuthorization();

app.UseDistributedThrottling();

app.MapControllers();

app.Run();

