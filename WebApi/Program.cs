using Persistence;
using Application;

var builder = WebApplication.CreateBuilder(args);
{
  // Register the controllers
  builder.Services.AddControllers();

  // Services Registration
  builder.Services
  .ConfigureApplicationServices()
  .ConfigurePersistenceServices(builder.Configuration);

  // Add services to the container.
  // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
  // Configure the HTTP request pipeline.
  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();
  }

  app.UseHttpsRedirection();
  app.MapControllers();

  app.Run();
}

