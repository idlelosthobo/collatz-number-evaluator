using CollatzNumberEvaluator.Models;

namespace CollatzNumberEvaluator.Tools;

public class Evaluator
{
    private int MaxPathLengthAppendLimit = 10000;

    private ulong ApplyAlgorithm(ulong number)
    {
        if (number % 2 == 0)
        {
            number /= 2;
        }
        else
        {
            number = (number * 3) + 1;
        }

        return number;
    }
    
    private Number ProcessNumber(Number number)
    {
        return new Number
        {
            Value = this.ApplyAlgorithm(number.Value),
        };
    }

}