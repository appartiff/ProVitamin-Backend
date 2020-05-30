using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repositories;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries.GetAllProducts;
using Application.Products.Queries.GetIsSkuExists;
using Application.Products.Queries.GetProduct;
using Domain.Entities.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Tita_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IProductRepository productRepository,IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>>  Get()
        {
            var product = await _mediator.Send(new GetAllProductsQuery());
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Product>> Get([FromBody]string id)
        {
            var product = await _mediator.Send(new GetProductQuery(){Id=id});
            if (product == null) 
                return NotFound();
            return Ok(product);
        }
        [HttpGet]
        public async Task<ActionResult<Product>> GetIsSkuExists([FromBody]string sku)
        {
            var productSku = await _mediator.Send(new GetIsSkuExistsQuery(){Sku= sku});
            return Ok(productSku);
        }
        
        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody]CreateProductCommand product)
        {
            var result= await _mediator.Send(product);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Product bookIn)
        {
            var product = await _mediator.Send(new GetProductQuery(){Id=bookIn.Id});
            if (product == null)
                return NotFound();
            await _mediator.Send(new UpdateProductCommand() {Product = product});
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _mediator.Send(new GetProductQuery(){Id=id});
            if (product == null)
                return NotFound();
            await _mediator.Send(new DeleteProductCommand() {Id = id});
            return NoContent();
        }
    }
}