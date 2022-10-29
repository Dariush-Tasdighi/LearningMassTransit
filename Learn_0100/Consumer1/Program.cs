using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder =
	Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
	x.AddConsumer<Consumer1.Consumers.ProductCreatedConsumer>();

	x.UsingRabbitMq((context, cfg) =>
	{
		cfg.ConfigureEndpoints(registration: context);
	});
});

//builder.Services.AddMassTransit(x =>
//{
//	x.UsingRabbitMq((context, cfg) =>
//	{
//		cfg.Host(host: "localhost", virtualHost: "/", configure: host =>
//		{
//			host.Username(username: "guest");
//			host.Password(password: "guest");
//		});

//		cfg.ConfigureEndpoints(registration: context);
//	});
//});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
