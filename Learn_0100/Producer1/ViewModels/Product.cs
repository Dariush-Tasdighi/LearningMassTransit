namespace ViewModels;

public class Product : object
{
	public Product() : base()
	{
	}

	public int Id { get; set; }

	public int Price { get; set; }

	public string? Name { get; set; }

	public string? Description { get; set; }
}
