using Microsoft.AspNetCore.Mvc;
using FlowerzAPI.Models;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
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

        //XXXTODO... GET       ->  /api/blooms/                 -> Gets all available blooms
        //GET       ->  /Bloom                 -> Gets all available blooms

        //GET       ->  /api/blooms/{id}             -> Gets the requested blooms
        //POST      ->  /api/blooms/{model}          -> Creates a new blooms
        //PUT       ->  /api/blooms/{model}          -> Updates an existing blooms
        //DELETE    ->  /api/blooms/{id}             -> Deletes an existing blooms

        //GET All blooms  
        [HttpGet]
        //public ActionResult<IEnumerable<Bloom>> GetBlooms()  // strongly typed/less flexible....
        public IActionResult GetBlooms()
        {
            //var data = await _customerService.GetBlooms(); //  TODO !
            //return data;
            return Ok(blooms);
        }

        ////GET All blooms  
        //[HttpGet]
        ////public ActionResult<IEnumerable<Bloom>> GetBlooms()  // strongly typed/less flexible....
        //public ActionResult <IEnumerable<Bloom>>     GetBlooms()
        //{
        //    //var data = await _customerService.GetCustomers();
        //    //return data;
        //    return blooms;
        //}

        ///// <summary> Get the requested customer </summary>
        //[HttpGet("{id}")]
        //[Produces("application/json")]
        //[ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        //public async Task<Customer> GetCustomer(long id)
        //{
        //    var data = await _customerService.GetCustomer(id);
        //    return data;
        //}
    }
}
