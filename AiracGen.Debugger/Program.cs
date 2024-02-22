using AiracGen;

var next = AiracGenerator.GenerateNext();

var airacs = AiracGenerator.GenerateFuture(20);

airacs.ForEach(x => Console.WriteLine(x.Ident));
