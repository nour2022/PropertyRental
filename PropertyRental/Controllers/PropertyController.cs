using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyRental.Application.DTOs;
using PropertyRental.Application.Services;

namespace PropertyRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : Controller
    {
        private PropertyAppService _propertyService;
        public PropertyController(PropertyAppService propertyService)
        {
            _propertyService = propertyService;
            
        }
        // GET: PropertyController
        [HttpGet("api/Property")]
        public ActionResult GetAll()
        {
          return Ok( _propertyService.GetAll());
        }

        // GET: PropertyController/Details/5
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
           return Ok( _propertyService.GetById(id));
            
        }

        // Post: PropertyController/Create
        [HttpPost]
        public ActionResult Create([FromBody]PropertyDTO propertyDTO)
        {
           _propertyService.Insert(propertyDTO);
            return Ok();
        }




        // GET: PropertyController/Edit/5
        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] PropertyDTO propertyDTO)
        {
            _propertyService.Update(propertyDTO,id);
            return Ok();
        }


        // GET: PropertyController/Delete/5
        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            _propertyService.Delete(id);
            return Ok();
        }
        [HttpGet("api/Property/Available")]
        public ActionResult GetAvailable()
        {
            
            return Ok(_propertyService.GetAvailable());
        }


    
    }
}
