using CollatzNumberEvaluator.Models;
using CollatzNumberEvaluator.Tools;
using LiteDB;
using Microsoft.VisualBasic;

namespace CollatzNumberEvaluator.App;


public class App
{

    private string ConnectionString = "Collatz.db";

    public Evaluator Evaluator = new Evaluator();

    public void Empty()
    {
        using var db = new LiteDatabase(this.ConnectionString);
        var numberCollection = this.GetNumberCollection(db);
        numberCollection.DeleteAll();
        var firstNumber = new Number
        {
            Value = 1,
            StepLength = 0,
            StepList = new List<ulong>()
        };

        numberCollection.Insert(firstNumber);

    }
    
    private ILiteCollection<Number> GetNumberCollection(LiteDatabase db)
    {
        return db.GetCollection<Number>("number");
    }
    
    public void Run()
    {
        using var db = new LiteDatabase(this.ConnectionString);
        var numberCollection = this.GetNumberCollection(db);
        Number lastNumber = numberCollection.FindOne(Query.All("Value", Query.Descending));

        var nextNumber = new Number
        {
            Value = lastNumber.Value + 1
        };

        var newNumber = Evaluator.ProcessNumber(nextNumber);
        numberCollection.Insert(newNumber);
        
        var results = numberCollection.Query();
        foreach (var result in results.ToList())
        {
            Console.WriteLine(result.ToString());
        }

    }
    
}