namespace AiracGen.Generator
{
    internal static partial class Gen
    {
        internal static List<Airac> GenerateMultiple(params string[] idents) => idents.Select(GenerateSingle).ToList();
    }
}
