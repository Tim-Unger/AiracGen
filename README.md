# AiracGen

## Quickstart

- **Vars are explicitly declared on purpose to help with documentation**

- **_List\<Airac\>_ is always sorted by oldest first, you will need to run your own _OrderBy()_ to re-sort the list to your liking**

- **Ident is a _string_ on purpose, if we used _int_, we would get incorrect idents when parsing (0901 would become 901 which is not a valid ident)**


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
Airac currentAirac = AiracGenerator.GenerateCurrent();
```

Generate the next Airac

(optional) you can provide a "base" ident from which the next Airac will be returned

```cs
Airac nextAirac = AiracGenerator.GenerateNext((optional)string ident);
```

Generate the previous Airac

(optional) you can provide a "base" ident from which the previous Airac will be returned

```cs
Airac previousAirac = AiracGenerator.GeneratePrevious((optional)string ident);
```

Generate a single Airac by ident

```cs
Airac singleAirac = AiracGenerator.GenerateSingle("2301");
```

Generate multiple Airacs by ident

```cs
List<Airac> multipleAiracs = AiracGenerator.GenerateMultiple("2301", "2302", "2303");
```

Generate all Airacs in a given year

If you only provide a two char long year, the system will assume that you mean the current century
```cs
List<Airac> airacs23 = AiracGenerator.GenerateByYear(2023);
```

## Extension Methods

Generate an Airac-JSON

You can run *ToJson()* on *Airac* and *List\<Airac\>*

```cs
string airacListJson = AiracGenerator.GenerateFuture(10).ToJson;
string airacJson = AiracGenerator.GenerateCurrent().ToJson;
```

Save an Airac-JSON

You can run *SaveJson(strng path)* on *Airac* and *List\<Airac\>*

This will save a .json to the provided path (you can use a full path (<yourPath>\airaclistname.json) or only the directory <youPath>\)

```cs
var currentDir = Environment.CurrentDirectory;
var airacs = AiracGenerator.GenerateFuture(10);
airacs.SaveJson(currentDir);
```

Get the next Airac based on the selected Airac

```cs
var nextAirac = AiracGenerator.GenerateSingle(2311).NextAirac();
```

Get the previous Airac based on the selected Airac

```cs
var nextAirac = AiracGenerator.GenerateSingle(2311).PreviousAirac();
```

# AiracGenCLI

### Simple Command-Application to quickly create a JSON with Airacs

Just define the amount of past and future airacs you want to generate (current airac will always be generated)
The JSON will be written to <currentDir>\Airacs.json
