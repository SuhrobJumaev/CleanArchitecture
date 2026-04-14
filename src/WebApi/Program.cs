using ApplicationService.Implementation;
using ApplicationServices.Interfaces;
using DataAccess.MsSql;
using DataAccess.Interfaces;
using DomainServices.Implementation;
using DomainServices.Interfaces;
using Email.MailHandler;
using Email.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Mobile.UseCases;
using Mobile.UseCases.Order.Commands.CreateOrder;
using WebApi;
using WebApi.Services;
using WebApp.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqlServer");


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArchitecture API", Version = "v1" });
});

//Entities
builder.Services.AddScoped<IOrderDomainService, OrderDomainService>();

//Infrastructure
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddDbContext<IDbContext, AppDbContext>(option => option.UseSqlServer(connectionString));

//Application
builder.Services.AddScoped<ISecurityService, SecurityService>();


//Frameworks
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddMediatR(typeof(CreateOrderCommand));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture API V1");
		c.RoutePrefix = string.Empty; // Swagger на корне http://localhost:5191/
	});
}

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();