using Microsoft.AspNetCore.Mvc;
using FlowerzAPI.Models;
//using CustomerAPI.Services;

namespace FlowerzAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BloomController : ControllerBase
    {
        //Define the variables
       // private readonly ICustomerService _customerService;

        /// <summary> Constructor </summary>
        public BloomController()//(ICustomerService customerService)
        {
           // _customerService = customerService;
         }

        // Temp until repo layer & EF added
        public static  List<Bloom> blooms = new List<Bloom>
        {
            new Bloom (1, "Sunflower", ""), new Bloom (2, "Nasturtium", "")
        };

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
            //var data = await _customerService.GetBlooms(); //  TODO !
            //return data;
            return Ok(blooms);
        }

        //GET the requested bloom  
        [HttpGet("{id}")]
        public IActionResult GetBloom(int id)
        {
            var bloom = blooms.FirstOrDefault(b => b.Id == id);  
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

            var maxId = blooms.Max(b  => b.Id);
            // var newBloom = new Bloom {  Id=maxId + 1, Name=bloom.Name, Description=bloom.Description };
            var newBloom = new Bloom(maxId + 1, bloom.Name, bloom.Description);
            blooms.Add(newBloom);
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

            var bloomToChange = blooms.FirstOrDefault(b => b.Id == id);
            if (bloomToChange == null)
                return NotFound($"Bloom does not exist for id {id}");

            var changedBloom = new  Bloom(id, bloom.Name, bloom.Description);
            // bloomToChange.Name = bloom.Name; can't do this as record is immutable
            var newBloom = new Bloom(id, bloom.Name, bloom.Description);
            blooms.Remove(bloomToChange);
            blooms.Add(newBloom);
            //return data;
            return Ok(newBloom);
        }

        //DELETE a bloom  
        [HttpDelete("{id}")]
        public IActionResult DeleteBloom(int id)
        {
            if (id <= 0)
                return BadRequest("Id must be specified for a bloom to be deleted");

            var bloomToDelete = blooms.FirstOrDefault(b => b.Id == id);
            if (bloomToDelete == null)
                return NotFound($"Bloom does not exist for id {id}");

            blooms.Remove(bloomToDelete);

            //return data;
            return NoContent();  // resource has been deleted, no additional info required
                                 // TODO it needs to be documented, how?
        }
    }
}
