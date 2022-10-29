using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder =
	Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
	x.UsingRabbitMq();
});

//builder.Services.AddMassTransit(x =>
//{
//	x.UsingRabbitMq((context, cfg) =>
//	{
//		cfg.Host(host: "localhost", virtualHost: "/", configure: host =>
//		{
//			host.Username(username: "guest1");
//			host.Password(password: "guest");
//		});

//		//cfg.ConfigureEndpoints(registration: context);

//		// Name of the primary exchange
//		cfg.Message<Producer1.Contracts.ProductCreated>
//			(e => e.SetEntityName(entityName: "product-created-event"));

//		// Primary exchange type
//		cfg.Publish<Producer1.Contracts.ProductCreated>
//			(e => e.ExchangeType = RabbitMQ.Client.ExchangeType.Topic);
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
