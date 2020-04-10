using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miso.Api.Models;
using MongoDB.Driver;

namespace Miso.Api.Context
{
    public interface IMisoContext
    {
        IMongoCollection<Post> Posts { get; }
    }
}
