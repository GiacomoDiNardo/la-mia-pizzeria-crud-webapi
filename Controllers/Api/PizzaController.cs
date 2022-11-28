using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]")]
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
    }
}
