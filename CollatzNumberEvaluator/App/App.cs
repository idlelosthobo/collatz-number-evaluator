using CollatzNumberEvaluator.Models;
using CollatzNumberEvaluator.Tools;
using LiteDB;

namespace CollatzNumberEvaluator.App;


public class App
{

    public Evaluator Evaluator = new Evaluator();
    public void Run()
    {
        using var db = new LiteDatabase("Collatz.db");
        
        var numberCollection = db.GetCollection<Number>("number");

        var newNumber = new Number
        {
            Value = 200
        };

        numberCollection.Insert(newNumber);

        var results = numberCollection.Query();

        foreach (var result in results.ToList())
        {
            Console.WriteLine(result.Value);
            
        }
        

    }
}