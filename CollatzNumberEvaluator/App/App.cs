using CollatzNumberEvaluator.Models;
using LiteDB;

namespace CollatzNumberEvaluator.App;


public class App
{
    public void Run()
    {
        using var db = new LiteDatabase("Collatz.db");
        var col = db.GetCollection<Number>("numbers");
        
        
        
    }
}