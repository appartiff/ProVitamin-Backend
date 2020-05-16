﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repositories;
using Domain.Entities.Product;
using Microsoft.AspNetCore.Mvc;

namespace Tita_Api.Controllers
{

    [Route("api/[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
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
        public ActionResult<Product> Create([FromBody]Product book)
        {
            if (string.IsNullOrEmpty(book.Sku) )
                return BadRequest();
            _productService.Create(book);
            return CreatedAtAction("Get", new {id = book.Details.Title}, book);
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
            _productService.Remove(product.Details.Title);
            return NoContent();
        }
    }
}