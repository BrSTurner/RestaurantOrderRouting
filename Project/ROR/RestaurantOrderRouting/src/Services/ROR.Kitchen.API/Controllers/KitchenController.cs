using Microsoft.AspNetCore.Mvc;
using ROR.WebAPI.Core.Controllers;
using System.Threading.Tasks;

namespace ROR.Kitchen.API.Controllers
{
    [ApiController]
    [Route("ror/api/[controller]")]
    public class KitchenController : MainController
    {
        [HttpPatch]
        [Route("CancelOrderItem/{id}")]
        public async Task<IActionResult> CancelOrderItem(int id)
        {
            //For future implementations :D
            return CustomResponse();
        }

        [HttpPatch]
        [Route("UpdateOrderItemStatus")]
        public async Task<IActionResult> UpdateOrderItemStatus(object updateOrderItemStatus)
        {
            //For future implementations :D
            return CustomResponse();
        }

    }
}
