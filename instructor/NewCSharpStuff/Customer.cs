
namespace NewCSharpStuff;

//public record Customer 
//{
//    public  string? Name { get; init; }

//    public  int? Age { get; init; }

//    public string NickName { get; init; } = string.Empty;

//}
// constructor syntax.
public record Customer(string? Name, int Age, string NickName);

public class Order { }