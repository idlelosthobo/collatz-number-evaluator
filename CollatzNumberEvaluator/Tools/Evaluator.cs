using System.Runtime.InteropServices;
using CollatzNumberEvaluator.Models;

namespace CollatzNumberEvaluator.Tools;

public class Evaluator
{
    private readonly BigInteger _stepLengthProcessLimit = 1000;

    private BigInteger ApplyAlgorithm(BigInteger number)
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
        BigInteger value = number.Value;
        bool isComplete = false;
        BigInteger stepValue = number.Value;
        List<BigInteger> stepList = new List<BigInteger>();
        BigInteger stepLength = 0;

        while (stepValue > 1 || stepLength >= _stepLengthProcessLimit)
        {
            stepValue = this.ApplyAlgorithm(stepValue);
            stepList.Add(stepValue);
            stepLength += 1;
        }

        isComplete = stepLength < _stepLengthProcessLimit;
        
        return new Number
        {
            Value = number.Value,
            IsComplete = isComplete,
            StepLength = stepLength,
            StepList = stepList
        };
    }

}