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
        private readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Brand>>>  Get()
        {
            return await _brandService.Get();
        } 
        
        [HttpPost( Name = "create")]
        public ActionResult<Brand> Create([FromBody]Brand brand)
        {
            if (string.IsNullOrEmpty(brand.Title) )
                return BadRequest();
            _brandService.Create(brand);
            return NoContent();
        }
    }
}