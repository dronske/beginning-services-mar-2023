// Everything in here goes to static Void Main


using NewCSharpStuff;

var c1 = new Customer("Jeffry", 53, "Jeff");






var c2 = new Customer
{
    Name = "Joe",
    Age = 40
};

if(c1 == c2)
{
    Console.WriteLine("They are the same!");
} else
{
    Console.WriteLine("They are NOT the same");
}