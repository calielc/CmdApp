# CmdApp

This is a command line application developed in .NET Core 2.0.

There are 2 avaiable commands 

## sequenceAnalysis
Find the uppercase words in a string, provided as input, and order all characters in these words alphabetically.

To Run: 
```
sequenceAnalysis --input <input text>
```

Sample: 
```
CmdApp\Runner> dotnet run sequenceAnalysis --input "This IS a STRING"
```

## sumOfMultiple
Find the sum of all natural numbers that are a multiple of 3 or 5 below a limit provided as input.

To Run: 
```
sumOfMultiple --limit <input value>
```

Sample: 
```
CmdApp\Runner> dotnet run sumOfMultiple --limit 100
```

