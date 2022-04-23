using fjapifestajuninadn.Models;
using fjapifestajuninadn.Services;
using Microsoft.AspNetCore.Mvc;

namespace fjapifestajuninadn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishesController : ControllerBase
    {

        private readonly DishesService _dishesService;
        public DishesController(DishesService dishesService) =>
            _dishesService = dishesService;

        [Route("dishlist")]
        [HttpGet]
        public async Task<List<Dish>> Get() => await _dishesService.GetAsync();

        [Route("{id:length(24)}")]
        [HttpGet]
        public async Task<ActionResult<Dish>> Get(string id)
        {
            var dish = await _dishesService.GetAsync(id);

            if (dish is null)
            {
                return NotFound();
            }

            return dish;
        }

        //[Route("dishadd")]
        [HttpPost]
        public async Task<IActionResult> Post(Dish newDish)
        {
            await _dishesService.CreateAsync(newDish);

            return CreatedAtAction(nameof(Get), new { id = newDish.Id }, newDish);
        }

        //[Route("dishupdate")]
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Dish updatedDish)
        {
            var dish = await _dishesService.GetAsync(id);

            if (dish is null)
            {
                return NotFound();
            }

            updatedDish.Id = dish.Id;

            await _dishesService.UpdateAsync(id, updatedDish);

            return NoContent();
        }

        //[Route("dishdelete")]
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _dishesService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _dishesService.RemoveAsync(id);

            return NoContent();
        }

    }
}
