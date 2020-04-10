using Miso.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miso.Api.Repositories
{
    public interface IPostRepository
    {
        // api/[GET]
        Task<IEnumerable<Post>> GetAll();
        // api/1/[GET]
        Task<Post> GetPost(long id);
        // api/[POST]
        Task Create(Post todo);
        // api/[PUT]
        Task<bool> Update(Post todo);
        // api/1/[DELETE]
        Task<bool> Delete(long id);
        Task<long> GetNextId();
    }
}
