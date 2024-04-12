using Cocona;

//CoconaApp.Run(([Argument(Description = "First Name")] string name, 
//               [Option(Description = "Last name")] string? lastName) =>
//{
//    Console.WriteLine($"Hello {name}");
//});

var builder = CoconaApp.CreateBuilder();



var app =  builder.Build();

app.Run();