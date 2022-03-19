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
    
    public Number ProcessNumber(Number number)
    {
        ulong value = number.Value;
        ulong stepValue = number.Value;
        List<ulong> stepList = new List<ulong>();
        ulong stepLength = 0;

        while (stepValue > 1)
        {
            stepValue = this.ApplyAlgorithm(stepValue);
            stepList.Add(stepValue);
            stepLength += 1;
        }
        
        
        return new Number
        {
            Value = number.Value,
            StepLength = stepLength,
            StepList = stepList
        };
    }

}