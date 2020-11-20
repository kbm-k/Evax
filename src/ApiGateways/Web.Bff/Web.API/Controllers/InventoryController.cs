using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Models.Inventory;
using Web.API.Services.Inventory.Interfaces;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IStuffTypeService _stuffTypeService;

        public InventoryController(IStuffTypeService stuffTypeService)
        {
            _stuffTypeService = stuffTypeService;
        }

        // GET: api/<InventoryController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var stuffTypes =  await _stuffTypeService.GetStuffTypesAsync();

            return stuffTypes.Select(x => x.Name);
        }

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InventoryController>
        [HttpPost]
        public async Task Post([FromBody] StuffTypeModel stuffType)
        {
            await _stuffTypeService.AddStuffTypeAsync(stuffType);
        }

        // PUT api/<InventoryController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] StuffTypeModel stuffType)
        {
            await _stuffTypeService.UpdateStuffTypeAsync(stuffType);
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _stuffTypeService.DeleteStuffTypeAsync(id);
        }
    }
}
