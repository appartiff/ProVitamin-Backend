using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Provitamin.Application.Common.Interfaces.Repositories;
using Provitamin.Domain.Entities;

namespace Tita_Api.Api
{

    [Route("api/[controller]/[action]")]
    public class BooksController : ControllerBase
    {
        private readonly IProductService _productService;

        public BooksController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>>  Get()
        {
           return await _productService.Get();
        } 

        [HttpGet("{id:length(24)}", Name = "GetProducts")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var product = await _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }
            return  product;
        }

        [HttpPost]
        public ActionResult<Product> Create(Product book)
        {
            _productService.Create(book);
            return CreatedAtRoute("GetBook", new {id = book.Id}, book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Product bookIn)
        {
            var product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _productService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }
            _productService.Remove(product.Id);
            return NoContent();
        }
    }
}