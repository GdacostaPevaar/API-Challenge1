using AutoMapper;
using Challenge1.Entities;
using Challenge1.Models;
using Challenge1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        // GET: api/<ProductoController>

        private readonly IGenericRepository<Producto> productorepository;
        private readonly IMapper _mapper;
        public ProductoController(IGenericRepository<Producto> _productorepository, IMapper mapper)
        {
            productorepository = _productorepository;



            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducto()
        {

            var Tipodeproducto = await productorepository.GetAll();
            return Ok(Tipodeproducto);
        }

        // GET api/<TipodeproductoController>/5
        [HttpGet]
        [Route("{id:int}")]


        public async Task<IActionResult> GetProductoById(int id)
        {


            var producto = await productorepository.GetById(id);


            if (producto != null)
            {

                return Ok(producto);
            }

            var productoDTO = _mapper.Map<ProductoDTO>(producto);

            return NotFound();
        }


        [HttpGet]
        [Route("/search")]


        public async Task<IActionResult> GetProductoByQuery(int id, [BindRequired] string s)
        {


            var producto = await productorepository.FindByCondition(q => q.Id.Equals(id)|| q.Descripcion.Contains(s));


            if (producto != null)
            {

                //return Ok($"s =  {producto.Descripcion}");


                return Ok(new object [] { producto.Descripcion, producto.Id });
            }

            var productoDTO = _mapper.Map<ProductoDTO>(producto);

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Post(ProductoDTO productoDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var producto = _mapper.Map<Producto>(productoDTO);

                producto = await productorepository.Insert(producto);

                return Ok(producto);
            }
            catch (Exception ex) { throw ex; }


        }

        // PUT api/<TipodeproductoController>/5

        [HttpPut]

        [Route("{id:int}")]

        public async Task<IActionResult> UpdateProducto(ProductoDTO productoDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (productoDTO.Id != id)
            {
                return BadRequest();
            }

            var tipodeproducto = await productorepository.GetById(id);

            if (tipodeproducto == null)
            {

                return NotFound();
            }

            try
            {

                var producto = _mapper.Map(productoDTO, tipodeproducto);

                producto = await productorepository.Update(producto);


                return Ok(producto);
            }
            catch (Exception ex) { throw ex; }



        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteProducto(int id)
        {


            var existingPost = await productorepository.GetById(id);

            if (existingPost == null)
            {
                return NotFound();
            }

            try
            {
                await productorepository.Delete(id);


                return Ok();
            }
            catch (Exception e) { throw e; }










        }
    }
    }
