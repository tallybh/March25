using Microsoft.AspNetCore.Mvc;
using Testing_Example.contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Testing_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get()
        {
           return Ok(await _productRepository.GetAll());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            var product =  await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Product))]
        public async Task<IActionResult> Post([FromBody] Product p)
        {
            var retVal = await _productRepository.Add(p);
            return Ok(retVal);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody] Product p)
        {
            var retVal = await _productRepository.Update(p);
            if (!retVal)
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var retVal = await _productRepository.Delete(id);
            if (!retVal)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
