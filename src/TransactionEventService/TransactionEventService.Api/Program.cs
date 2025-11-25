using Microsoft.EntityFrameworkCore;
using TransactionEventService.Application.Interfaces;
using TransactionEventService.Domain.Interfaces;
using TransactionEventService.Infrastructure.Data;
using TransactionEventService.Infrastructure.Messaging;
using TransactionEventService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDb")));

builder.Services.AddScoped<ITransactionEventRepository, TransactionEventRepository>();
builder.Services.AddSingleton<IEventPublisher, EventPublisher>();
builder.Services.AddScoped<ITransactionEventService, TransactionEventService.Application.Services.TransactionEventService>();

builder.Services.AddHostedService<RabbitMqConsumer>();


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

app.Run();
