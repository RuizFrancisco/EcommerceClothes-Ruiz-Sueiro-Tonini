using AutoMapper;
using EcommerceClothes.Models;
using EcommerceClothes.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceClothes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        [Authorize("BothPolicy")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_productService.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetById/{id}")]
        [Authorize("AdminPolicy")]
        public IActionResult GetById(int id)
        {
            try
            {
                var product = _productService.GetById(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetByName/{name}")]
        [Authorize("BothPolicy")]
        public IActionResult GetByName(string name)
        {
            try
            {
                return Ok(_productService.GetByName(name));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("CreateProduct")]
        [Authorize("AdminPolicy")]
        public IActionResult CreateProduct([FromBody] ProductDTO productDTO)
        {
            try
            {
                _productService.Add(productDTO);
                return StatusCode(201);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateProduct/{id}")]
        [Authorize("AdminPolicy")]
        public IActionResult Update(int id, [FromBody] ProductDTO productDTO)
        {
            try
            {
                _productService.Update(id, productDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteProduct/{id}")]
        [Authorize("AdminPolicy")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.Delete(id);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
