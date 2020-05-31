using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products.Commands.CreateCategory;
using Application.Products.Commands.DeleteCategoryCommand;
using Application.Products.Queries.GetAllCategories;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Tita_Api.Controllers
{
    
    [Route("api/[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<Category>>>  Get()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());
            if (result == null)
                return NotFound();
            return Ok(result);
        } 
        
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody]string category)
        {
            if (string.IsNullOrEmpty(category) )
                return BadRequest();
            var result = await _mediator.Send(new CreateCategoryCommand() {Category = category});
            return Ok(result);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(Category category)
        {
            if (string.IsNullOrEmpty(category.Id) )
                return BadRequest();
            var product = await _mediator.Send(new DeleteCategoryCommand() {Category = category});
            if (product == null)
                return NotFound();
            return Ok(product);
        }
    }
}