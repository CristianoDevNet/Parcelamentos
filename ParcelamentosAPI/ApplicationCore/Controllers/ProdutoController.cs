using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceCore.Services;
using ServiceCore.Validators;

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

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    try
        //    {
        //        return Ok(await service.GetByIdAsync(id));
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return NotFound(ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {            
            try
            {
                await service.PostAsync<ProdutoValidator>(produto);

                return Ok(produto.Id);
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

        //[HttpPut]
        //public async Task<IActionResult> Put([FromBody] Produto produto)
        //{
        //    try
        //    {
        //        await service.PutAsync<ProdutoValidator>(produto);

        //        return Ok(produto);
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await service.DeleteAsync(id);

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}