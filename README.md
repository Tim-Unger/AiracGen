# AiracGen

## Quickstart

**Vars are explicitly declared on purpose to help with documentation**

**_List\<Airac\>_ is always sorted by oldest first, you will need to run your own _OrderBy()_ to re-sort the list to your liking**



```cs
using AiracGen;
```

Generate Airacs in the future

```cs
int airacAmount = 100;

List<Airac> airacs = AiracGenerator.GenerateFuture(airacAmount);
```

Generate Airacs in the past

```cs
int airacAmount = 100;

List<Airac> airacs = AiracGenerator.GeneratePast(airacAmount);
```

Generate Airacs in the past and future

```cs
int pastAiracAmount = 10;
int futureAiracAmount = 100;

List<Airac> airacs = AiracGenerator.GeneratePastAndFuture(pastAiracAmount, futureAiracAmount);
```

Generate the current Airac

```cs
Airac curentAirac = AiracGenerator.GenerateCurrent();
```

Generate the next Airac
(optional) 

```cs
Airac curentAirac = AiracGenerator.GenerateNext(<pre><i>(optional)</i></pre> string ident);
```

Generate a single Airac by ident

```cs
Airac singleAirac = AiracGenerator.GenerateSingle("2301");
```

Generate multiple Airacs by ident

```cs
List<Airac> multipleAiracs = AiracGenerator.GenerateMultiple("2301", "2302", "2303");
```

Generate an Airac-JSON

You can run *ToJson()* on *Airac* and *List\<Airac\>*

```cs
string airacListJson = AiracGenerator.GenerateFuture(10).ToJson;
string airacJson = AiracGenerator.GenerateCurrent().ToJson;
```

# AiracGenCLI

### Simple Command-Application to quickly create a JSON with Airacs

Just define the amount of past and future airacs you want to generate (current airac will always be generated)
The JSON will be written to <currentDir>\Airacs.json
