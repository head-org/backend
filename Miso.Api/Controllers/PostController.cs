using Miso.Api.Models;
using Miso.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miso.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IPostRepository _repo;
        public PostsController(IPostRepository repo)
        {
            _repo = repo;
        }

        // GET api/todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostResponseModel>>> Get()
        {
            var posts = await _repo.GetAll();
            return new ObjectResult(posts.Select(x => x.ToResponseModel()));
        }

        // GET api/todos/1
        [HttpGet("{id}")]
        public async Task<ActionResult<PostResponseModel>> Get(long id)
        {
            var post = await _repo.GetPost(id);
            if (post == null)
                return new NotFoundResult();

            return new ObjectResult(post.ToResponseModel());
        }

        // POST api/todos
        [HttpPost]
        public async Task<ActionResult<PostResponseModel>> Create([FromBody] PostRequestModel source)
        {
            var post = Post.FromRequestModel(source);

            post.Id = await _repo.GetNextId();
            await _repo.Create(post);
            return new OkObjectResult(post.ToResponseModel());
        }
    }
}
