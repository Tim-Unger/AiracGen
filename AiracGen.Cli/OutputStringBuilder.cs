using System.Text;

namespace AiracGen.Cli
{
    public enum AiracType
    {
        Current,
        Next,
        Previous,
        Ident,
        Year
    }

    internal class Strings
    {
        internal static string BuildOutputString(List<(Airac Airac, AiracType Type)> airacs)
        {
            if(airacs.Count == 0)
            {
                return "";
            }

            var stringBuilder = new StringBuilder();

            foreach (var airac in airacs)
            {
                var startString = airac.Type switch
                {
                    AiracType.Current => "Current:",
                    AiracType.Next => "Next:",
                    AiracType.Previous => "Previous:",
                    AiracType.Ident => "Ident:",
                    AiracType.Year => "",
                    _ => throw new ArgumentOutOfRangeException()
                };

                stringBuilder.AppendLine($"{startString} {airac.Airac.Ident}, starts {airac.Airac.StartDate.ToShortDateString()}, ends: {airac.Airac.EndDate.ToShortDateString()}");
            }

            return stringBuilder.ToString();
        }
    }
}
