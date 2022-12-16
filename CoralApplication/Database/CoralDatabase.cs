using MongoDB.Driver;

namespace CoralApplication.Database;

public class CoralDatabase
{
    private const string? ConnectionString =
        "mongodb+srv://aemmerling:Laangels27@cluster0.ls6ot.mongodb.net/?retryWrites=true&w=majority";

    private const string? DatabaseName = "coral";

    public static IMongoCollection<T> Connect<T>(in string collection)
    {
        var client = new MongoClient(ConnectionString);
        var database = client.GetDatabase(DatabaseName);
        return database.GetCollection<T>(collection);
    }
}