using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.Api.Models;
using ProductsManagement.Application.IServices;
using ProductsManagement.Common.Resources;
using ProductsManagement.Domain.DTOs;

namespace ProductsManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/products
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productService.GetProducts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/products/{productId}
        [HttpGet]
        [Route("Get/{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(productId);
                if (product == null)
                {
                    return NotFound(Messages.ProductNotFound);
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/products
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Post([FromBody] ProductDto product)
        {
            try
            {
                await _productService.CreateProduct(product);
                return Ok(Messages.ProductCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/products
        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Put([FromBody] ProductDto productDto)
        {
            try
            {
                var product = await _productService.GetById(productDto.Id);

                if (product == null)
                {
                    return NotFound(Messages.ProductNotFound);
                }

                await _productService.UpdateProduct(productDto, product);
                return Ok(Messages.ProductUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/products/{productId}
        [HttpDelete]
        [Route("Delete/{productId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {
                var product = await _productService.GetById(productId);

                if (product == null)
                {
                    return NotFound(Messages.ProductNotFound);
                }

                await _productService.DeleteProduct(product);
                return Ok(Messages.ProductDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
