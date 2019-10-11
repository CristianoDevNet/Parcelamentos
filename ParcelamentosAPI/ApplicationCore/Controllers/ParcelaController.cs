using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceCore.Services;
using ServiceCore.Validators;

namespace ApplicationCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelaController : ControllerBase
    {
        private BaseService<Parcela> service = new BaseService<Parcela>();

        // GET: api/Parcela
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Parcela/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Parcela
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Parcela parcela)
        {
            try
            {
                //await service.PostAsync<ParcelaValidator>(parcela);

                return Ok(parcela.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Parcela/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
