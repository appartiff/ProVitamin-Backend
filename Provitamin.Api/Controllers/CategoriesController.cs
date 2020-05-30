using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
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
        [HttpGet]
        public async Task<ActionResult<List<Category>>>  Get()
        {
            return await _categoryRepository.Get();
        } 
        
        [HttpPost]
        public async Task<ActionResult<Category>> Create([FromBody]Category brand)
        {
            if (string.IsNullOrEmpty(brand.id) )
                return BadRequest();
            _categoryRepository.Create(brand);
            return CreatedAtAction("Get", new { title = brand.id}, brand);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(Category brand)
        {
            var product = await _categoryRepository.Get(brand.Id);

            if (product == null)
            {
                return NotFound();
            }
            _categoryRepository.Remove(brand.Id);
            return NoContent();
        }
    }
}