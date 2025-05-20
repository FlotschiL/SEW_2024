using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class MongoManager
{
    private readonly IMongoCollection<BsonDocument> _collection;
    private readonly IMongoDatabase _database;
    private readonly MongoClient _client;

    public MongoManager(string connectionString, string dbName, string collectionName)
    {
        _client = new MongoClient(connectionString);
        _database = _client.GetDatabase(dbName);
        _collection = _database.GetCollection<BsonDocument>(collectionName);
    }

    // CREATE
    public async Task InsertAsync(Dictionary<string, object?> data)
    {
        var doc = new BsonDocument(data);
        await _collection.InsertOneAsync(doc);
    }

    // READ ALL
    public async Task<List<Dictionary<string, object>>> GetAllAsync()
    {
        var list = await _collection.Find(FilterDefinition<BsonDocument>.Empty).ToListAsync();
        return list.Select(doc => doc.ToDictionary()).ToList();
    }

    // READ BY FIELD
    public async Task<List<Dictionary<string, object>>> FindByFieldAsync(string fieldName, object value)
    {
        var filter = Builders<BsonDocument>.Filter.Eq(fieldName, BsonValue.Create(value));
        var list = await _collection.Find(filter).ToListAsync();
        return list.Select(doc => doc.ToDictionary()).ToList();
    }

    // UPDATE
    public async void UpdateFieldAsync(string id, string fieldName, object newValue)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
        var update = Builders<BsonDocument>.Update.Set(fieldName, BsonValue.Create(newValue));
        await _collection.UpdateOneAsync(filter, update);
    }

    // DELETE
    public async void DeleteByIdAsync(string id)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
        await _collection.DeleteOneAsync(filter);
    }

    // DELETE ALL
    public async void DeleteAllAsync()
    {
        await _collection.DeleteManyAsync(FilterDefinition<BsonDocument>.Empty);
    }

    // CREATE SAMPLE DATA
    public async Task CreateSampleData(string firstNamesPath, string lastNamesPath, int maxAge = 100)
    {
        if (!File.Exists(firstNamesPath) || !File.Exists(lastNamesPath))
        {
            Console.WriteLine("Name files not found.");
            return;
        }

        var firstnames = File.ReadAllLines(firstNamesPath).OrderBy(x => Guid.NewGuid()).ToArray();
        var lastnames = File.ReadAllLines(lastNamesPath).OrderBy(x => Guid.NewGuid()).ToArray();

        Random rng = new Random();

        int count = Math.Min(firstnames.Length, lastnames.Length);
        for (int i = 0; i < count; i++)
        {
            var person = new Dictionary<string, object>
            {
                { "Name", firstnames[i].Trim() },
                { "LastName", lastnames[i].Trim() },
                { "Age", rng.Next(maxAge) },
                { "Gender", rng.Next(2) == 1 ? (rng.Next(35) == 1 ? "Divers" : "Male") : "Female" }
            };

            await InsertAsync(person);
        }

        Console.WriteLine($"{count} random people inserted.");
    }
}
