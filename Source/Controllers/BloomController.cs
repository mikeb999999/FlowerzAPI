using Microsoft.AspNetCore.Mvc;
using Flowerz.Models;
using FlowerzAPI.Services;

namespace FlowerzAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    /// My controllers are based on "A base class for an MVC controller without view support" as opposed to 'Controller' 
    /// base class which has view support...
    public class BloomController : ControllerBase
    {
        //Define the local variables
        private readonly IBloomService _bloomService;

        /// <summary> Constructor </summary>
        public BloomController(IBloomService bloomService)
        {
            _bloomService = bloomService;
        }

        //GET       ->  /Bloom                 -> Gets all available blooms
        //GET       ->  /Bloom/{id}            -> Gets the requested bloom
        //POST      ->  /Bloom/{model}         -> Creates a new bloom
        //PUT       ->  /Bloom/{id}            -> Updates an existing bloom
        //DELETE    ->  /Bloom/{id}            -> Deletes an existing bloom

        //GET All blooms  
        [HttpGet]
        //public ActionResult<IEnumerable<Bloom>> GetBlooms()  // strongly typed/less flexible....
        public async Task<IActionResult> GetBlooms()
        {
            var data = await _bloomService.GetBlooms();
            return Ok(data);
        }

        //GET the requested bloom  
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBloom(int id)
        {
            var bloom = await _bloomService.GetBloom(id);

            //return data;
            return Ok(bloom);
        }

        //POST create a bloom  
        [HttpPost]
        public async Task<IActionResult> PostBloom([FromBody] Bloom bloom)
        {
            return Ok(bloom);
            //if (bloom == null)
            //    return BadRequest("No bloom specified - can't create");
            //if (bloom.Id != 0)
            //    return BadRequest("Id must be 0 when creating a bloom");

            //var maxId = _context.Blooms.Max(b => b.Id);
            //var newBloom = new Bloom() { Id = maxId + 1, Name = bloom.Name, Description = bloom.Description };
            //_context.Blooms.Add(newBloom);
            //_context.SaveChanges();
            ////return data;
            //return Ok(newBloom);
        }

        //PUT update a bloom  
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloom(int id, [FromBody] Bloom bloom)
        {
            return null;
            //if (bloom == null)
            //    return BadRequest("No bloom specified - can't update");
            //if (id <= 0)
            //    return BadRequest("Id must be specified for a bloom to be updated");
            //if (bloom.Id != id)
            //    return BadRequest("A bloom's id cannot be changed");

            //var bloomToChange = _context.Blooms.FirstOrDefault(b => b.Id == id);
            //if (bloomToChange == null)
            //    return NotFound($"Bloom does not exist for id {id}");

            //bloomToChange.Name = bloom.Name;
            //bloomToChange.Description = bloom.Description;
            //_context.Blooms.Update(bloomToChange);
            //_context.SaveChanges();
            ////return data;
            //return Ok(bloomToChange);
        }

        //DELETE a bloom  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBloom(int id)
        {
            return null;
            //if (id <= 0)
            //    return BadRequest("Id must be specified for a bloom to be deleted");

            //var bloomToDelete = _context.Blooms.FirstOrDefault(b => b.Id == id);
            //if (bloomToDelete == null)
            //    return NotFound($"Bloom does not exist for id {id}");

            //_context.Blooms.Remove(bloomToDelete);
            //_context.SaveChanges();

            ////return data;
            //Response.Headers.Append("Documentation|Description|Message", $"Bloom {id} successfully deleted");
            //return NoContent();  // resource has been deleted, no additional info required
        }
    }
}
