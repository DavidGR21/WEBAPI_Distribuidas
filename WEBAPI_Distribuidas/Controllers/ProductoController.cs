using Microsoft.AspNetCore.Mvc;
using WEBAPI_Distribuidas.Models;
using WEBAPI_Distribuidas.Services;

namespace WEBAPI_Distribuidas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _service = new ProductoService();



        [HttpPost]
        public ActionResult<Producto> Post([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest();

            var creado = _service.Add(producto);
            return CreatedAtAction(nameof(Get), new { id = creado.Id }, creado);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto producto)
        {
            if (!_service.Update(id, producto))
                return NotFound();

            return NoContent();
        }
    }
}