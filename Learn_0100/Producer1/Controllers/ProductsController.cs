//namespace Producer1.Controllers;

//[Microsoft.AspNetCore.Mvc.ApiController]
//[Microsoft.AspNetCore.Mvc.Route("[controller]")]
//public class ProductsController : Microsoft.AspNetCore.Mvc.ControllerBase
//{
//	public ProductsController(MassTransit.IBus bus)
//	{
//		Bus = bus;
//	}

//	private MassTransit.IBus Bus { get; }

//	[Microsoft.AspNetCore.Mvc.HttpGet]
//	public ViewModels.Product Get()
//	{
//		var product =
//			new ViewModels.Product
//			{
//				Id = 1,
//				Price = 10,
//				Name = "Product 1",
//				Description = "Nothing!",
//			};

//		var productCreated =
//			new Contracts.ProductCreated(Id: product.Id, Name: product.Name);

//		Bus.Publish(message: productCreated);

//		return product;
//	}
//}

namespace Producer1.Controllers;

[Microsoft.AspNetCore.Mvc.ApiController]
[Microsoft.AspNetCore.Mvc.Route("[controller]")]
public class ProductsController : Microsoft.AspNetCore.Mvc.ControllerBase
{
	public ProductsController(MassTransit.IPublishEndpoint publishEndpoint)
	{
		PublishEndpoint = publishEndpoint;
	}

	private MassTransit.IPublishEndpoint PublishEndpoint { get; }

	[Microsoft.AspNetCore.Mvc.HttpGet]
	public async System.Threading.Tasks.Task<ViewModels.Product> Get()
	{
		var product =
			new ViewModels.Product
			{
				Id = 1,
				Price = 10,
				Name = "Product 1",
				Description = "Nothing!",
			};

		var productCreated =
			new Contracts.ProductCreated(Id: product.Id, Name: product.Name);

		//await PublishEndpoint.Publish<Contracts.ProductCreated>(message: productCreated);

		await PublishEndpoint.Publish(message: productCreated);

		return product;
	}
}
