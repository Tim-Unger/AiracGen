using AiracGen;

var next = AiracGenerator.GeneratePrevious();

var airacs = AiracGenerator.GenerateFuture(20);

airacs.ForEach(x => Console.WriteLine(x.Ident));
