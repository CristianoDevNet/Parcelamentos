using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceCore.Services;

namespace ApplicationCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        private BaseService<Orcamento> service = new BaseService<Orcamento>();

        // GET: api/Orcamento/5
        [HttpGet("produto/{id}")] //Lista todos os orçamentos de um determinado produto
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await service.GetByConditionAsync(orcamento => orcamento.ProdutoId.Equals(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        await service.DeleteAsync(id);

        //        return NoContent();
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
