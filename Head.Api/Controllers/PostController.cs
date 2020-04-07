using Head.Api.Models;
using Head.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Head.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class PostsController : Controller
    {
        private readonly IPostRepository _repo;
        public PostsController(IPostRepository repo)
        {
            _repo = repo;
        }

        // GET api/todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> Get()
        {
            return new ObjectResult(await _repo.GetAll());
        }

        // GET api/todos/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(long id)
        {
            var post = await _repo.GetPost(id);
            if (post == null)
                return new NotFoundResult();

            return new ObjectResult(post);
        }

        // POST api/todos
        [HttpPost]
        public async Task<ActionResult<Post>> Post([FromBody] Post post)
        {
            post.Id = await _repo.GetNextId();
            await _repo.Create(post);
            return new OkObjectResult(post);
        }
    }
}
