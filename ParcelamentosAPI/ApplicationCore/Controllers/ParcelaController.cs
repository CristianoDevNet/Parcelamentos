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
    public class ParcelaController : ControllerBase
    {
        private BaseService<Parcela> service = new BaseService<Parcela>();

        // GET: api/Parcela/5
        [HttpGet("orcamento/{id}")] //Lista todas as parcelas de um determinado orçamento
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await service.GetByConditionAsync(parcela => parcela.OrcamentoId.Equals(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
