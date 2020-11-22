using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RichModel.Application.Orders.Commands.CreateOrder;
using RichModel.WebUI.Controllers.Common;

namespace RichModel.WebUI.Controllers.Orders
{
    public class OrdersController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}