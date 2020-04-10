using Miso.Api.Context;
using Miso.Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miso.Api.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IMisoContext _context;
        public PostRepository(IMisoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context
                            .Posts
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<Post> GetPost(long id)
        {
            FilterDefinition<Post> filter = Builders<Post>.Filter.Eq(m => m.Id, id);
            return _context
                    .Posts
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(Post post)
        {
            await _context.Posts.InsertOneAsync(post);
        }

        public async Task<bool> Update(Post post)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Posts
                        .ReplaceOneAsync(
                            filter: g => g.Id == post.Id,
                            replacement: post);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(long id)
        {
            FilterDefinition<Post> filter = Builders<Post>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                                                .Posts
                                              .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<long> GetNextId()
        {
            return await _context.Posts.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}
