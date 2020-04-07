using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Head.Api.Infrastructure
{
    public class ServerConfig
    {
        public MongoDBConfig MongoDB { get; set; } = new MongoDBConfig();
    }
}
