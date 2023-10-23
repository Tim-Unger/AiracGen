namespace AiracGen.Generator
{
    internal class Multiple
    {
        internal static List<Airac> Generate(params string[] idents) => idents.Select(Single.Generate).ToList();
    }
}
