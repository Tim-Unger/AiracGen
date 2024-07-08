namespace AiracGen.Tests
{
    public class Tests
    {

        [Test]
        public void AreAllIdentsValidShoudReturnTrue()
        {
            var years = new List<int>() { 2000 };

            for (var i = 2000; i < 2099; i++) 
            {
                years.Add(i + 1);
            }

            var airacs = new List<Airac>();

            foreach (var year in years)
            {
                var airacsInYear = AiracGenerator.GenerateByYear(year);
                airacs.AddRange(airacsInYear);
            }

            var idents = airacs.Select(x => x.Ident);

            if (idents.Any(x => x.Length != 4))
            {
                Assert.Fail();
            }
        }
    }
}