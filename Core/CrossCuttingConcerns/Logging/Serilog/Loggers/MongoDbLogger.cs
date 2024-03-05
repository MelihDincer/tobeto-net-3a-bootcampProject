using MongoDB.Driver;
using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
public class MongoDbLogger : LoggerServiceBase
{
    public MongoDbLogger()
    {
        Logger = new LoggerConfiguration().WriteTo.MongoDBBson(
            cfg =>
            {
                MongoClient client = new("mongodb://localhost:27017");
                IMongoDatabase? database = client.GetDatabase("logs2");
                cfg.SetMongoDatabase(database);
            }
            ).CreateLogger();
    }
}
