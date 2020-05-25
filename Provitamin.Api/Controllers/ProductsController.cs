using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repositories;
using Application.Products.Commands;
using Application.Products.Queries;
using Application.Products.Queries.GetAllProducts;
using Application.Products.Queries.GetProduct;
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
            var product = await _mediator.Send(new GetAllProductsQuery());
            if (product == null) {
                return NotFound();
            }
            return Ok(product);
        } 

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var product = await _mediator.Send(new GetProductQuery(){Id=id});
            if (product == null) {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody]CreateProductCommand product)
        {
            var result= await _mediator.Send(product);
            return Ok(result);
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