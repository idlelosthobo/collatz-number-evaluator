using System.Diagnostics;
using CollatzNumberEvaluator.Models;
using CollatzNumberEvaluator.Tools;
using LiteDB;

namespace CollatzNumberEvaluator.App;


public class App
{

    private string ConnectionString = "Collatz.db";

    private Evaluator Evaluator = new Evaluator();

    public void Empty()
    {
        using var db = new LiteDatabase(this.ConnectionString);
        var numberCollection = this.GetNumberCollection(db);
        numberCollection.DeleteAll();
        var firstNumber = new Number
        {
            Value = 1,
            IsComplete = true,
            StepLength = 0,
            StepList = new List<BigInteger>()
        };

        numberCollection.Insert(firstNumber);

    }
    
    private ILiteCollection<Number> GetNumberCollection(LiteDatabase db)
    {
        return db.GetCollection<Number>("number");
    }
    
    public void Run()
    {
        const int numberRunLimit = 200000;
        using var db = new LiteDatabase(this.ConnectionString);
        var numberCollection = this.GetNumberCollection(db);
        Number lastNumber = numberCollection.FindOne(Query.All("Value", Query.Descending));
        
        var startNumber = new Number
        {
            Value = lastNumber.Value
        };

        var timer = new Stopwatch();

        timer.Start();
        Console.WriteLine($"Processing {numberRunLimit} Numbers with the Collatz Algorithm");
        for (int i = 0; i < numberRunLimit; i++)
        {

            startNumber.Value += 1;    
            var newNumber = Evaluator.ProcessNumber(startNumber);
            numberCollection.Insert(newNumber);
            if (i % (numberRunLimit / 10) == 0)
            {
                Console.WriteLine($"{i} of {numberRunLimit} Completed");
            }
            
        }
        timer.Stop();
        Console.WriteLine($"Run Time: {timer.Elapsed.ToString()}");

    }
    
}