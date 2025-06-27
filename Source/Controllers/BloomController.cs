using Microsoft.AspNetCore.Mvc;
using Flowerz.DataContexts;
using Flowerz.EntityModels;

namespace FlowerzAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BloomController : ControllerBase
    {
        //Define the variables
        // private readonly IBloomService _bloomService;

        //Define the local variables
        private FlowerzContext _context; // Temp! will be moved to repository layer

        /// <summary> Constructor </summary>
        public BloomController(
            FlowerzContext context
            )//(IBloomService bloomService)
        {
            _context = context;
           // _bloomService = bloomService;
         }

        //GET       ->  /Bloom                 -> Gets all available blooms
        //GET       ->  /Bloom/{id}            -> Gets the requested bloom
        //POST      ->  /Bloom/{model}         -> Creates a new bloom
        //PUT       ->  /Bloom/{id}            -> Updates an existing bloom
        //DELETE    ->  /Bloom/{id}            -> Deletes an existing bloom

        //GET All blooms  
        [HttpGet]
        //public ActionResult<IEnumerable<Bloom>> GetBlooms()  // strongly typed/less flexible....
        public IActionResult GetBlooms()
        {
            //var data = await _bloomService.GetBlooms(); //  TODO !
            //return data;
            var blooms = _context.Blooms;
            return Ok(blooms);
        }

        //GET the requested bloom  
        [HttpGet("{id}")]
        public IActionResult GetBloom(int id)
        {
            var bloom = _context.Blooms.FirstOrDefault(b => b.Id == id);  
            if (bloom == null)
                return NotFound($"Bloom does not exist for id {id}");
            //return data;
            return Ok(bloom);
        }

        //POST create a bloom  
        [HttpPost]
        public IActionResult PostBloom([FromBody] Bloom bloom)
        {
            if (bloom == null)
               return BadRequest("No bloom specified - can't create");
            if (bloom.Id != 0)
                return BadRequest("Id must be 0 when creating a bloom");

            var maxId = _context.Blooms.Max(b  => b.Id);
            var newBloom = new Bloom() { Id = maxId + 1, Name = bloom.Name, Description = bloom.Description };
            _context.Blooms.Add(newBloom);
            _context.SaveChanges();
            //return data;
            return Ok(newBloom);
        }

        //PUT update a bloom  
        [HttpPut("{id}")]
        public IActionResult PutBloom(int id, [FromBody] Bloom bloom)
        {
            if (bloom == null)
                return BadRequest("No bloom specified - can't update");
            if (id <= 0)
                return BadRequest("Id must be specified for a bloom to be updated");
            if (bloom.Id != id)
                return BadRequest("A bloom's id cannot be changed");

            var bloomToChange = _context.Blooms.FirstOrDefault(b => b.Id == id);
            if (bloomToChange == null)
                return NotFound($"Bloom does not exist for id {id}");

            bloomToChange.Name = bloom.Name;
            bloomToChange.Description = bloom.Description;
            _context.Blooms.Update(bloomToChange);
            _context.SaveChanges();
            //return data;
            return Ok(bloomToChange);
        }

        //DELETE a bloom  
        [HttpDelete("{id}")]
        public IActionResult DeleteBloom(int id)
        {
            if (id <= 0)
                return BadRequest("Id must be specified for a bloom to be deleted");

            var bloomToDelete = _context.Blooms.FirstOrDefault(b => b.Id == id);
            if (bloomToDelete == null)
                return NotFound($"Bloom does not exist for id {id}");

            _context.Blooms.Remove(bloomToDelete);
            _context.SaveChanges(); 

            //return data;
            Response.Headers.Append("Documentation|Description|Message", $"Bloom {id} successfully deleted");
            return NoContent( );  // resource has been deleted, no additional info required
        }
    }
}
