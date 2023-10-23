using AiracGen;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

//Default Start Airac
var startDate = new DateOnly(2022, 01, 27);
var endDate = startDate.AddDays(28);
var startIdent = "2201";
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

        startIdent = nextYearIdent;

        continue;
    }

    startNumber += 1;

    var ident = int.Parse(startIdent.Substring(2, 2));

    var setIndex = ident > 8 ? 2 : 3;
    var takeIndex = setIndex == 3 ? 1 : 2;

    var identYear = startIdent[..setIndex];
    var identNumber = int.Parse(startIdent.Substring(setIndex, takeIndex)) + 1;

    startIdent = $"{identYear}{identNumber}";
}

//Set the values of the current Airac (for the past values later)
var currentStart = startDate;
var currentEnd = endDate;
var currentIdent = startIdent;
var currentNumber = startNumber;

Console.WriteLine("Enter the number of Airacs in the Future you want to generate");

//We can use discard as the value is set in the out constructor and thrown with the ternary operator
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

        var nextIdent = nextYearIdent;

        airac.Ident = nextIdent;
        airac.NumberInYear = startNumber;

        airacs.Add(airac);

        startIdent = nextIdent;
        continue;
    }

    startNumber += 1;
    startIdent = $"{startIdent[..3]}{int.Parse(startIdent.Substring(3, 1)) + 1}";

    airac.Ident = startIdent;
    airac.NumberInYear = startNumber;

    airacs.Add(airac);
}

Console.WriteLine("Enter the number of Airacs in the Past you want to generate");
_ = int.TryParse(Console.ReadLine(), out var pastAiracsCount) ? 0 : throw new InvalidDataException();

startDate = currentStart;
endDate = currentEnd;
startIdent = currentIdent;
startNumber = currentNumber;

for (var i = 0; i <= pastAiracsCount; i++)
{
    var airac = new Airac();

    startDate = startDate.AddDays(-28);
    endDate = endDate.AddDays(-28);

    airac.StartDate = startDate;
    airac.EndDate = endDate;

    if (startDate.Year != startDate.AddDays(28).Year)
    {
        var maxAmountOfCyclesInYear = 0;
        var currentYear = startDate;

        var firstDayOfCurrentYear = new DateOnly(currentYear.Year, 1, 1);
        while (firstDayOfCurrentYear.Year == firstDayOfCurrentYear.AddDays(28).Year)
        {
            maxAmountOfCyclesInYear ++;
            firstDayOfCurrentYear = firstDayOfCurrentYear.AddDays(28);
        }

        //Decrement the Airac Ident to the previous year
        var startIdentYear = int.Parse(startIdent.ToString()[..2]);

        //Rollover from 2000 to 1999, since 2000 would be 0, 1999 would be -1, so we have to set the value to 100 to get 99 with the next subtraction
        if(startIdentYear == 0)
        {
            startIdentYear = 100;
        }

        var previousYearIdent = $"{startIdentYear -= 1}{maxAmountOfCyclesInYear}";

        if (startIdentYear < 10)
        {
            previousYearIdent = "0" + previousYearIdent;
        }

        startNumber = maxAmountOfCyclesInYear;

        var nextIdent = previousYearIdent;

        airac.Ident = nextIdent;
        airac.NumberInYear = startNumber;

        airacs.Add(airac);

        startIdent = nextIdent;
        continue;
    }
    startNumber -= 1;

    var ident = int.Parse(startIdent.Substring(2, 2));

    var setIndex = ident > 8 ? 2 : 3;
    var takeIndex = setIndex == 3 ? 1 : 2;

    var identYear = startIdent[..2];
    var identNumber = int.Parse(startIdent.Substring(setIndex, takeIndex)) - 1;

    var identString = identNumber.ToString();

    if(identNumber < 10)
    {
        identString = "0" + identNumber;
    }

    startIdent = $"{identYear}{identString}";

    airac.Ident = startIdent;
    airac.NumberInYear = startNumber;

    airacs.Add(airac);
}

airacs = airacs.OrderBy(x => x.StartDate).ToList();

var airacPath = $@"{Environment.CurrentDirectory}\Airacs.txt";

File.WriteAllText(airacPath, JsonSerializer.Serialize(airacs, new JsonSerializerOptions() { WriteIndented = true}));

Console.WriteLine($"{airacs.Count} Airacs generated in {airacPath}");

Process.Start("notepad.exe", airacPath);

//airacs.ForEach(x => Console.WriteLine($"{x.Ident} - {x.NumberInYear} - {x.StartDate.ToShortDateString()} - {x.EndDate.ToShortDateString()}"));