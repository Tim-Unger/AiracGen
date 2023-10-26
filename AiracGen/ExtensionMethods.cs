using System.Text.Json;

namespace AiracGen
{
    public static class JsonExtension
    {
        private static readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        public static string ToJson(this List<Airac> airacs) => JsonSerializer.Serialize(airacs, _options);

        public static string ToJson(this Airac airac) => JsonSerializer.Serialize(airac, _options);

        public static void SaveJson(this List<Airac> airacs, string path) => File.WriteAllText(GetFullPath(path), JsonSerializer.Serialize(airacs, _options));

        public static void SaveJson(this Airac airac, string path) => File.WriteAllText(GetFullPath(path), JsonSerializer.Serialize(airac, _options));

        private static string GetFullPath(string path)
        {
            if (path.EndsWith(".json"))
            {
                return path;
            }

            return $@"{path}\Airacs.json";
        }
    }

    public static class AiracExtensions
    {
        public static Airac NextAirac(this Airac airac) => AiracGenerator.GenerateNext(airac.Ident);

        public static Airac PreviousAirac(this Airac airac) => AiracGenerator.GeneratePrevious(airac.Ident);
    }
}
