using ECommerce.Core.Abstractions;
using ECommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService service)
        {
            _productsService = service;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                IEnumerable<Product> result = await _productsService.GetAllProducts();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to get All products:{ex.Message}");
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                Product product = await _productsService.GetProduct(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to get product:{ex.Message}");
            }
        }

        // PUT: api/Products/6
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var exist = await _productsService.ProductExists(id);
            if (!exist)
            {
                return NotFound();
            }

            try
            {
                await _productsService.UpdateProduct(product);
                return Ok();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to update a product:{ex.Message}");
            }

        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            try
            {
                await _productsService.AddProduct(product);
                return CreatedAtAction("GetProduct", new { id = product.Id }, product);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to create a products:{ex.Message}");
            }

        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _productsService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            try
            {
                await _productsService.DeleteProduct(product);
                return Ok(product);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to delete a product:{ex.Message}");
            }

        }

    }
}
