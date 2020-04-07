using Head.Api.Infrastructure;
using Head.Api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Head.Api.Context
{
    public class HeadContext : IHeadContext
    {
        private readonly IMongoDatabase _db;

        public HeadContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<Post> Posts => _db.GetCollection<Post>("Posts");
    }
}
