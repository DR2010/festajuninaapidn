using fjapifestajuninadn.Models;
using fjapifestajuninadn.Services;
using Microsoft.AspNetCore.Mvc;

namespace fjapifestajuninadn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly OrdersService _ordersService;
        public OrdersController(OrdersService ordersService) =>
            _ordersService = ordersService;

        [Route("orderlist")]
        [HttpGet]
        public async Task<List<Order>> Get() => await _ordersService.GetAsync();

        [Route("{id:length(24)}")]
        [HttpGet]
        public async Task<ActionResult<Order>> Get(string id)
        {
            var order = await _ordersService.GetAsync(id);

            if (order is null)
            {
                return NotFound();
            }

            return order;
        }

        //[Route("dishadd")]
        [HttpPost]
        public async Task<IActionResult> Post(Order newOrder)
        {
            await _ordersService.CreateAsync(newOrder);

            return CreatedAtAction(nameof(Get), new { id = newOrder.id }, newOrder);
        }

        //[Route("dishupdate")]
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Order updatedOrder)
        {
            var order = await _ordersService.GetAsync(id);

            if (order is null)
            {
                return NotFound();
            }

            updatedOrder.id = order.id;

            await _ordersService.UpdateAsync(id, updatedOrder);

            return NoContent();
        }

        //[Route("dishdelete")]
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _ordersService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _ordersService.RemoveAsync(id);

            return NoContent();
        }

    }
}
