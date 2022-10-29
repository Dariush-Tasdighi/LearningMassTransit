namespace Consumer1.Controllers;

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
	public string Get()
	{
		return "OK";
	}
}
