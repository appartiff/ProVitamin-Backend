using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Product;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;

namespace Tita_Api.Controllers
{
    
    [Route("api/[controller]/[action]")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        public BrandsController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        [HttpGet(Name ="get")]
        public async Task<ActionResult<List<Brand>>>  Get()
        {
            return await _brandRepository.Get();
        } 
        
        [HttpPost( Name = "create")]
        public async Task<ActionResult<Brand>> Create([FromBody]Brand brand)
        {
            if (string.IsNullOrEmpty(brand.Title) )
                return BadRequest();
            _brandRepository.Create(brand);
            return CreatedAtAction("Get", new { title = brand.Title}, brand);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]Brand brand)
        {
            var product = await _brandRepository.Get(brand.Title);

            if (product == null)
            {
                return NotFound();
            }
            _brandRepository.Remove(brand.Title);
            return NoContent();
        }
    }
}