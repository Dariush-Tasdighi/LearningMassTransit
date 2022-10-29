namespace Consumer1.Consumers;

public class ProductCreatedConsumer : object,
	MassTransit.IConsumer<Producer1.Contracts.ProductCreated>
{
	public ProductCreatedConsumer() : base()
	{
	}

	public System.Threading.Tasks.Task Consume
		(MassTransit.ConsumeContext<Producer1.Contracts.ProductCreated> context)
	{
		var productName =
			context.Message.Name;

		return System.Threading.Tasks.Task.CompletedTask;
	}
}
