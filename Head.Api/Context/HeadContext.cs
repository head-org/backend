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

            // Create index for location. This needs future review and configuration 
            // https://stackoverflow.com/questions/51248295/mongodb-c-sharp-driver-create-index
            var indexs = new IndexKeysDefinitionBuilder<Post>().Geo2DSphere(x => x.Location);

            var indexModel = new CreateIndexModel<Post>(indexs);
            Posts.Indexes.CreateOne(indexModel);
        }

        public IMongoCollection<Post> Posts => _db.GetCollection<Post>("Posts");
    }
}
