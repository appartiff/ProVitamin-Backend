using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repositories;
using Application.Products.Queries;
using Domain.Entities.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Tita_Api.Controllers
{

    [Route("api/[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;
        public ProductsController(IProductRepository productRepository,IMediator mediator)
        {
            _productRepository = productRepository;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>>  Get()
        {
           return await _productRepository.Get();
        } 

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var product = await _mediator.Send(new GetAllProductsQuery());
            if (product == null) {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Create([FromBody]Product book)
        {
            if (string.IsNullOrEmpty(book.Sku) )
                return BadRequest();
            _productRepository.Create(book);
            return CreatedAtAction("Get", new {id = book.Details.Title}, book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Product bookIn)
        {
            var product = _productRepository.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _productRepository.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productRepository.Get(id);

            if (product == null)
            {
                return NotFound();
            }
            _productRepository.Remove(product.Details.Title);
            return NoContent();
        }
    }
}