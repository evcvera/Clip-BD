using MongoDB.Driver;
using System;
using System.Linq;


namespace Clip2020Api.Repositories
{
    public class MongoDbRepository
    {
        public MongoClient client;
        public IMongoDatabase db;

        public MongoDbRepository()
        {
            var client = new MongoClient("mongodb+srv://evcvera:ernestit0@cluster0.emsok.mongodb.net/Clip2020?retryWrites=true&w=majority");
            db = client.GetDatabase("Clip2020");


        }
    }
}
