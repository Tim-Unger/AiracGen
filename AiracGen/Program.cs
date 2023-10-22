using AiracGen;
using System.Diagnostics;
using System.Text.Json;

//Default Start Airac
var startDate = new DateOnly(2022, 01, 27);
var endDate = startDate.AddDays(28);
var startIdent = 2201;
var startNumber = 1;

var dateOnlyNow = DateOnly.FromDateTime(DateTime.UtcNow);


//Users Date is somehow in the past
if(dateOnlyNow < startDate)
{
    throw new UnreachableException("You have somehow travelled to the past");
}

//Determine the current Airac
while (startDate < dateOnlyNow && endDate < dateOnlyNow)
{
    startDate = startDate.AddDays(28);
    endDate = endDate.AddDays(28);

    //Increment the Airac Ident to the next year
    if (startDate.Year != startDate.AddDays(-28).Year)
    {
        var startIdentYear = int.Parse(startIdent.ToString()[..2]);

        var nextYearIdent = $"{startIdentYear += 1}01";
        startNumber = 1;

        startIdent = int.Parse(nextYearIdent);

        continue;
    }

    startNumber += 1;
    startIdent += 1;
}

//Set the values of the current Airac (for the past values later)
var currentStart = startDate;
var currentEnd = endDate;
var currentIdent = startIdent;
var currentNumber = startNumber;

Console.WriteLine("Enter the number of Airacs in the Future you want to generate");
_ = int.TryParse(Console.ReadLine(), out var futureAiracsCount) ?  0 : throw new InvalidDataException();

var airacs = new List<Airac>()
{
    new Airac()
    {
        StartDate = startDate,
        EndDate = endDate,
        Ident = startIdent,
        NumberInYear = startNumber,
    }
};

for (var i = 0; i < futureAiracsCount - 1; i++)
{
    var airac = new Airac();

    startDate = startDate.AddDays(28);
    endDate = endDate.AddDays(28);

    airac.StartDate = startDate;
    airac.EndDate = endDate;

    if (startDate.Year != startDate.AddDays(-28).Year)
    {
        //Increment the Airac Ident to the next year
        var startIdentYear = int.Parse(startIdent.ToString()[..2]);

        var nextYearIdent = $"{startIdentYear += 1}01";
        startNumber = 1;

        var nextIdent = int.Parse(nextYearIdent);

        airac.Ident = nextIdent;
        airac.NumberInYear = startNumber;

        airacs.Add(airac);

        startIdent = nextIdent;
        continue;
    }

    startNumber += 1;
    startIdent += 1;

    airac.Ident = startIdent;
    airac.NumberInYear = startNumber;

    airacs.Add(airac);
}

//TODO find out how to set the ident correctly for Airacs in the past

//Console.WriteLine("Enter the number of Airacs in the Past you want to generate");
//_ = int.TryParse(Console.ReadLine(), out var pastAiracsCount) ? 0 : throw new InvalidDataException();

//startDate = currentStart;
//endDate = currentEnd;
//startIdent = currentIdent;
//startNumber = currentNumber;

//for (var i = 0; i <= pastAiracsCount; i++)
//{
//    var airac = new Airac();

//    startDate = startDate.AddDays(-28);
//    endDate = endDate.AddDays(-28);

//    airac.StartDate = startDate;
//    airac.EndDate = endDate;

//    if (startDate.Year != startDate.AddDays(28).Year)
//    {
//        //Increment the Airac Ident to the next year
//        var startIdentYear = int.Parse(startIdent.ToString()[..2]);

//        var previousYearIdent = $"{startIdentYear -= 1}01";
//        startNumber = 1;

//        var nextIdent = int.Parse(previousYearIdent);

//        airac.Ident = nextIdent;
//        airac.NumberInYear = startNumber;

//        airacs.Add(airac);

//        startIdent = nextIdent;
//        continue;
//    }

//    startNumber += 1;
//    startIdent += 1;

//    airac.Ident = startIdent;
//    airac.NumberInYear = startNumber;

//    airacs.Add(airac);
//}

//airacs = airacs.OrderBy(x => x.StartDate).ToList();

var airacPath = $@"{Environment.CurrentDirectory}\Airacs.txt";

File.WriteAllText(airacPath, JsonSerializer.Serialize(airacs, new JsonSerializerOptions() { WriteIndented = true}));

Console.WriteLine($"{airacs.Count} Airacs generated in {airacPath}");

Process.Start("notepad.exe", airacPath);

//airacs.ForEach(x => Console.WriteLine($"{x.Ident} - {x.NumberInYear} - {x.StartDate.ToShortDateString()} - {x.EndDate.ToShortDateString()}"));