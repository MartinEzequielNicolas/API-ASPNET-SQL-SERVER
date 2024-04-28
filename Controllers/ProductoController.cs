using app.Dtos;
using app.Models;
using app.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
       
        public readonly ProductRepository _ProductRepository;
        public ProductoController(ProductRepository productRepository_)
        {
            _ProductRepository = productRepository_;

        }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var productos = await _ProductRepository.Get();

            return Ok(productos);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult>  GetById(int Id)
        {
           var product = await _ProductRepository.GetByid(Id);

            return Ok(product);
        }


        [HttpPost]

        public async Task<IActionResult> Insert(ProductoDto producto)
        {
            await _ProductRepository.Insert(producto);

            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update( int id, ProductoDto producto)
        {
            await _ProductRepository.Update(id, producto);

            return Ok();

        }

        public async Task<IActionResult> Delete(int id )
        {
            await _ProductRepository.Delete(id);

            return Ok();   
        }
    }
}
