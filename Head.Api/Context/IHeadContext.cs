using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Head.Api.Models;
using MongoDB.Driver;

namespace Head.Api.Context
{
    public interface IHeadContext
    {
        IMongoCollection<Post> Posts { get; }
    }
}
