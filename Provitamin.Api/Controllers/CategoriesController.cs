using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Tita_Api.Controllers
{
    
    [Route("api/[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet(Name ="get")]
        public async Task<ActionResult<List<Category>>>  Get()
        {
            return await _categoryRepository.Get();
        } 
        
        [HttpPost( Name = "create")]
        public async Task<ActionResult<Category>> Create([FromBody]Category brand)
        {
            if (string.IsNullOrEmpty(brand.Title) )
                return BadRequest();
            _categoryRepository.Create(brand);
            return CreatedAtAction("Get", new { title = brand.Title}, brand);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]Category brand)
        {
            var product = await _categoryRepository.Get(brand.Title);

            if (product == null)
            {
                return NotFound();
            }
            _categoryRepository.Remove(brand.Title);
            return NoContent();
        }
    }
}