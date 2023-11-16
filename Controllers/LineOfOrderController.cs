using EcommerceClothes.Models;
using EcommerceClothes.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceClothes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineOfOrderController : ControllerBase
    {
        private readonly ILineOfOrderService _lineOfOrderService;

        public LineOfOrderController(ILineOfOrderService lineOfOrderService)
        {
            _lineOfOrderService = lineOfOrderService;
        }

        [HttpGet("GetLineOfOrder/{id}")]
        [Authorize("AdminPolicy")]
        public IActionResult GetLineOfOrder(int id)
        {
            return Ok(_lineOfOrderService.GetLineOfOrder(id));
        }

        [HttpPost("AddLineOfOrder")]
        [Authorize("ClientPolicy")]
        public IActionResult AddLineOfOrder([FromBody] LineOfOrderDTO lineOfOrderDTO, int orderId)
        {
            try
            {
                _lineOfOrderService.AddLineOfOrder(orderId, lineOfOrderDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateLineOfOrder/{id}")]
        [Authorize("ClientPolicy")]
        public IActionResult UpdateLineOfOrder(int id, [FromBody] LineOfOrderDTO lineOfOrderDTO)
        {
            try
            {
                _lineOfOrderService.UpdateLineOfOrder(id, lineOfOrderDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteLineOfOrder{id}")]
        [Authorize("AdminPolicy")]
        public IActionResult DeleteLineOfOrder(int id)
        {
            try
            {
                _lineOfOrderService.DeleteLineOfOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
