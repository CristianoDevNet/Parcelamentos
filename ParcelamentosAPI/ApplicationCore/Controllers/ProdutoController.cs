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
    public class ProdutoController : ControllerBase
    {
        private BaseService<Produto> service = new BaseService<Produto>();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await service.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}