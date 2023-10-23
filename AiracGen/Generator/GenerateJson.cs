using System.Text.Json;

namespace AiracGen.Generator
{
    public static class JsonExtension
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions() { WriteIndented = true };

        public static string ToJson(this List<Airac> airacs) => JsonSerializer.Serialize(airacs, _options);

        public static string ToJson(this Airac airac) => JsonSerializer.Serialize(airac, _options);
    }
}
