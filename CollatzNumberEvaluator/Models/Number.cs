using LiteDB;

namespace CollatzNumberEvaluator.Models;

public class Number
{
    public BigInteger Value { get; set; }
    public bool IsComplete { get; set; }
    public BigInteger StepLength { get; set; }
    public List<BigInteger> StepList { get; set; }

    public new string ToString()
    {
        string data = $"Value: {this.Value} Is Complete: {this.IsComplete} Step Length: {this.StepLength} Step List: {string.Join(", ", this.StepList)}";
        return data;
    }
    
}

