// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

arguments a = CommandParser.CommandParser.parse<arguments>(args);

Console.WriteLine("###########################################################");
Console.WriteLine($"{a.id}, {a.id.GetType()}");
Console.WriteLine($"{a.password}, {a.password.GetType()}");
Console.WriteLine($"{a.year}, {a.year.GetType()}");
Console.WriteLine($"{a.month}, {a.month.GetType()}");

struct arguments
{
    public string id;
    public string password;
    public int year;
    public int month;

    public arguments(string id, string password, int year, int month)
    {
        this.id = id;
        this.password = password;
        this.year = year;
        this.month = month;
    }

    public arguments() : this("default", "default", 200, 1)
    {
    }
}