using Microsoft.AspNetCore.Mvc;
using WebApiExample.Contracts;
using WebApiExample.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiExample.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ILogger<FilesController> _logger; 
        private readonly IFiles  _service;
        public FilesController(IFiles service, ILogger<FilesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [ProducesResponseType(200, Type = typeof(List<string>))]
        [ProducesResponseType(404)]
        [HttpGet]
        [Route("GetDirs/{dirName}")]
        public IActionResult GetFilesByDirectory(string dirName)
        {
            var files = _service.GetFiles(dirName);
            if(files == null)
            {
                _logger.LogWarning("No files found in directory {dirName}", dirName);
                return NotFound();
            }
            return files == null ? NotFound() : Ok(files);
        }


       
    }
}
