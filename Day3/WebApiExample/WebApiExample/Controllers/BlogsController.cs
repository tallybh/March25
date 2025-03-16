using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _repository;
        public BlogsController(IBlogRepository repository) {
            _repository = repository;
        }
        // GET: api/<BlogsController>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Blog>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetBlogs());
        }

        // GET api/<BlogsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Blog))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            var blog = await _repository.GetBlog(id);
            return blog == null ? NotFound() : Ok(blog);
        }

        // POST api/<BlogsController>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Post([FromBody] Blog blog)
        {
            await _repository.AddBlog(blog);
            return Ok();
        }

        // PUT api/<BlogsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody] Blog blog)
        {
            var updated = await _repository.UpdateBlog(blog);
            return updated ? Ok() : NotFound();
        }

        // DELETE api/<BlogsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteBlog(id);
            return deleted ? Ok() : NotFound();
        }
    }
}
