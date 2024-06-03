using Microsoft.AspNetCore.Mvc;
using ROR.Core.Mediator;
using ROR.Orders.API.Application.Commands.Orders;
using ROR.WebAPI.Core.Controllers;
using System.Threading.Tasks;

namespace ROR.Orders.API.Controllers
{
    [Route("ror/api/[Controller]")]
    public class OrderController : MainController
    {
        private readonly IMediatorHandler _mediator;
        public OrderController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceNewOrder(NewOrderCommand newOrderCommand)
        {
            try
            {
                return CustomResponse(await _mediator.SendCommand(newOrderCommand));
            }
            catch
            {
                AddProcessingError("Something went wrong placing the order");

                return CustomResponse();
            }
        }
    }
}
