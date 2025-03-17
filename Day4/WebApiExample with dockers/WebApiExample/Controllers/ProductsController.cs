using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.Extensions.Options;
using WebApiExample.Contracts;
using WebApiExample.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repository;
        private readonly IOptions<Units> _units;
        private readonly IOptionsSnapshot<Units> _unitsSnapshotoptions;
        private readonly IOptionsMonitor<Units> _unitsMonitor;
        public ProductsController(IProductsRepository repository, IOptions<Units> unitOptions, 
                                  IOptionsSnapshot<Units> unitsSnapshotoptions , IOptionsMonitor<Units> unitsMonitor)
        {
            _units = unitOptions;
            _repository = repository;
            _unitsSnapshotoptions = unitsSnapshotoptions;
            _unitsMonitor = unitsMonitor;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        public IActionResult Get()
        {
            return Ok(_repository.GetProducts());
        }

        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var p = _repository.GetProduct(id);
            return p == null ? NotFound() : Ok(p);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Post([FromBody] Product p)
        {
            _repository.AddProduct(p);
            return Ok();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody] Product p)
        {
            p.Id = id;
            _repository.UpdateProduct(p);
            return Ok();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            return _repository.DeleteProduct(id) ?  Ok() :  NotFound();
        }
    }
}
