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

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var producto = _service.GetById(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        //corregir errores
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

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_service.Delete(id))
                return NotFound();

            return NoContent();
        }
    }
}
