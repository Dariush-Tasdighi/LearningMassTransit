namespace Producer1.Contracts;

//public class ProductCreated : object
//{
//	public ProductCreated() : base()
//	{
//	}

//	public int Id { get; set; }

//	public string? Name { get; set; }
//}

// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record

//public record ProductCreated : object
//{
//	public ProductCreated() : base()
//	{
//	}

//	public int Id { get; init; }

//	public string? Name { get; init; }
//}

public record ProductCreated(int Id, string Name);
