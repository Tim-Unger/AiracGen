using Cocona;
using AiracGen;

namespace AiracGen.Cli
{
    internal class Program
    {
        static void Main()
        {
            var builder = CoconaApp.CreateBuilder();

            var app = builder.Build();

            app.AddCommand(
                (
                    [Option('c')] bool? current,
                    [Option('n')] bool? next,
                    [Option('p')] bool? previous,
                    [Option('i')] string? ident,
                    [Option('y')] string[]? years
                ) =>
                {
                    var airacs = new List<(Airac, AiracType)>();

                    if (current == true)
                    {
                        var currentAirac = AiracGenerator.GenerateCurrent();
                        airacs.Add((currentAirac, AiracType.Current));
                    }

                    if (next == true)
                    {
                        var nextAirac = AiracGenerator.GenerateNext();
                        airacs.Add((nextAirac, AiracType.Next));
                    }

                    if (previous == true)
                    {
                        var previousAirac = AiracGenerator.GeneratePrevious();
                        airacs.Add((previousAirac, AiracType.Previous));
                    }

                    if (ident is not null)
                    {
                        var airac = AiracGenerator.GenerateByIdent(ident);
                        airacs.Add((airac, AiracType.Ident));
                    }

                    if (years is not null)
                    {
                        foreach (var year in years)
                        {
                            //For some reason using the opposite as a guard clause does not work
                            if (year.Length is 2 or 4)
                            {
                                if (!int.TryParse(year, out var yearInt))
                                {
                                    throw new InvalidDataException("Year was not a valid int");
                                }

                                //We turn a two letter long year into a 4 letter one (23 => 2023)
                                if (year.Length == 2)
                                {
                                    yearInt += 2000;
                                }

                                var yearAiracs = AiracGenerator.GenerateByYear(yearInt);

                                foreach (var yearAirac in yearAiracs)
                                {
                                    airacs.Add((yearAirac, AiracType.Year));
                                }

                                continue;
                            }
                            throw new InvalidDataException("Year was not 4 or 2 chars long");
                        }
                    }

                    Console.WriteLine(Strings.BuildOutputString(airacs));
                }
            );

            app.Run();
        }
    }
}
