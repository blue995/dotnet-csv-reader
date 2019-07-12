# Read CSV files

## Features

* Flexible value delimiters
* Named values (values of the first line represent the names of each value in the column)

## Important

There should be no duplicate values in the first line.

## Example

```csharp
// Returns a list of dictionaries
var dataTuples = CSVMainApi.GetDataTuples("data.csv", ';');
foreach (var dataTuple in dataTuples)
{
    // Each dictionary represents a line in the CSV
    foreach (var keyValueTuple in dataTuple)
    {
        // Each key in the dictionary is the column name
        var key = keyValueTuple.Key;
        // Each value in the dictionary is the value of the current line in this column  
        var value = keyValueTuple.Value;
        /* Do some stuff with your values ;) */
    }
}
```
