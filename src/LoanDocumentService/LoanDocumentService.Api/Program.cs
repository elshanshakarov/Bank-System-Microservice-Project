using LoanDocumentService.Application.Interfaces;
using LoanDocumentService.Domain.Interfaces;
using LoanDocumentService.Infrastructure.Data;
using LoanDocumentService.Infrastructure.Repositories;
using LoanDocumentService.Infrastructure.Storage;
using LoanDocumentService.Infrastructure.Validation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDb")));

builder.Services.AddScoped<ILoanDocumentRepository, LoanDocumentRepository>();
builder.Services.AddScoped<IFileStorage, LocalFileStorage>();
builder.Services.AddScoped<IFileValidator, FileValidator>();
builder.Services.AddScoped<ILoanDocumentService, LoanDocumentService.Application.Services.LoanDocumentService>();


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
