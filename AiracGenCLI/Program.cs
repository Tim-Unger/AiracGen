using AiracGen;
using System.Diagnostics;
using System.Text.Json;

Console.WriteLine("Enter the number of Airacs in the Future you want to generate");

//We can use discard as the value is set in the out constructor and thrown with the ternary operator
_ = int.TryParse(Console.ReadLine(), out var futureAiracsCount) ?  0 : throw new InvalidDataException();

Console.WriteLine("Enter the number of Airacs in the Past you want to generate");
_ = int.TryParse(Console.ReadLine(), out var pastAiracsCount) ? 0 : throw new InvalidDataException();

var airacs = AiracGenerator.GeneratePastAndFuture(pastAiracsCount, futureAiracsCount);

var test = AiracGenerator.GenerateSingle("2512");

airacs = airacs.OrderBy(x => x.StartDate).ToList();

var airacPath = $@"{Environment.CurrentDirectory}\Airacs.txt";

File.WriteAllText(airacPath, JsonSerializer.Serialize(airacs, new JsonSerializerOptions() { WriteIndented = true}));

Console.WriteLine($"{airacs.Count} Airacs generated in {airacPath}");

Process.Start("notepad.exe", airacPath);

Console.WriteLine("Program will close in 5 seconds");

//await Task.Delay(5000);

//airacs.ForEach(x => Console.WriteLine($"{x.Ident} - {x.NumberInYear} - {x.StartDate.ToShortDateString()} - {x.EndDate.ToShortDateString()}"));