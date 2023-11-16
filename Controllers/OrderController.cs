using EcommerceClothes.Models;
using EcommerceClothes.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceClothes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        [HttpGet("GetAll")]
        [Authorize("AdminPolicy")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_orderService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOrderById{id}")]
        [Authorize("AdminPolicy")]
        public IActionResult GetOrderById(int id)
        {
            try
            {
                return Ok(_orderService.GetOrderById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOrdersByClientId{clientId}")]
        [Authorize("AdminPolicy")]
        public IActionResult GetOrdersByClientId(int clientId)
        {
            try
            {
                return Ok(_orderService.GetOrdersByClientId(clientId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddOrder")]
        [Authorize("ClientPolicy")]
        public IActionResult AddOrder([FromBody] OrderDTO orderDTO)
        {
            try
            {
                _orderService.AddOrder(orderDTO);
                return StatusCode(201);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteOrderById")]
        [Authorize("AdminPolicy")]
        public IActionResult DeleteOrderById(int id)
        {
            try
            {
                _orderService.DeleteOrder(id);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
