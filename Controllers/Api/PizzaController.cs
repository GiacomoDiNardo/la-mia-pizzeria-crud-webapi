using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]", Order = 1)]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        IDbPizzeriaRepository _pizzeriaRepository;

        public PizzaController(IDbPizzeriaRepository pizzeriaRepository)
        {
            _pizzeriaRepository = pizzeriaRepository;
        }

        public IActionResult Get()
        {
            List<Pizza> pizzas = _pizzeriaRepository.All();
            return Ok(pizzas);
        }

        public IActionResult Search(string? title)
        {

            List<Pizza> pizzas = _pizzeriaRepository.SearchByTitle(title);

            return Ok(pizzas);

        }


        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Pizza pizza = _pizzeriaRepository.GetById(id);

            return Ok(pizza);
        }
    }
}
