using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerentesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {

        private FilmeContext _context;
        private IMapper _mapper;

        public GerenteController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarGerentePorID), new { Id = gerente.Id }, gerente);
        }

        [HttpGet]
        public IEnumerable<Gerente> RecuperarGerentes()
        {
            return _context.Gerentes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerentePorID(int id) 
        { 
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

                return Ok(gerente);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarGerente(int id, [FromBody] UpdateGerenteDto gerenteDto)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }

            _mapper.Map(gerenteDto, gerente);
            _context.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }
            _context.Remove(gerente);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
