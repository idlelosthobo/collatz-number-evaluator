using LiteDB;

namespace CollatzNumberEvaluator.Models;

public class Number
{
    public ulong Value { get; set; }
    public ulong StepLength { get; set; }
    public List<ulong> StepList { get; set; }

    public new string ToString()
    {
        string data = $"Value: {this.Value} Step Length: {this.StepLength} Step List: {string.Join(", ", this.StepList)}";
        return data;
    }
    
}

