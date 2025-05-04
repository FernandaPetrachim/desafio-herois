using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;
using SuperHeroApi.Dtos;
using SuperHeroApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SuperHeroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HeroisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/herois
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeroiReadDto>>> GetHerois()
        {
            var herois = await _context.Herois
                .Include(h => h.HeroisSuperpoderes)
                .ThenInclude(hs => hs.Superpoder)
                .ToListAsync();

            if (herois == null || !herois.Any())
                return NotFound("Nenhum herói encontrado.");

            var dto = herois.Select(h => new HeroiReadDto
            {
                Id = h.Id,
                Nome = h.Nome,
                NomeHeroi = h.NomeHeroi,
                DataNascimento = h.DataNascimento,
                Altura = h.Altura,
                Peso = h.Peso,
                Superpoderes = h.HeroisSuperpoderes.Select(hs => hs.Superpoder.SuperpoderNome).ToList()
            });

            return Ok(dto);
        }

        // GET: api/herois/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<HeroiReadDto>> GetHeroi(int id)
        {
            var heroi = await _context.Herois
                .Include(h => h.HeroisSuperpoderes)
                .ThenInclude(hs => hs.Superpoder)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (heroi == null)
                return NotFound($"Herói com ID {id} não encontrado.");

            var dto = new HeroiReadDto
            {
                Id = heroi.Id,
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                DataNascimento = heroi.DataNascimento,
                Altura = heroi.Altura,
                Peso = heroi.Peso,
                Superpoderes = heroi.HeroisSuperpoderes.Select(hs => hs.Superpoder.SuperpoderNome).ToList()
            };

            return Ok(dto);
        }

        // POST: api/herois
        [HttpPost]
        public async Task<ActionResult> PostHeroi(HeroiCreateDto dto)
        {
            if (_context.Herois.Any(h => h.NomeHeroi.ToLower() == dto.NomeHeroi.ToLower()))
                return BadRequest("Nome de herói já está em uso.");

            var heroi = new Heroi
            {
                Nome = dto.Nome,
                NomeHeroi = dto.NomeHeroi,
                DataNascimento = dto.DataNascimento,
                Altura = dto.Altura,
                Peso = dto.Peso,
                HeroisSuperpoderes = new List<HeroiSuperpoder>()
            };

            foreach (var id in dto.SuperpoderesIds)
            {
                if (!_context.Superpoderes.Any(s => s.Id == id))
                    return BadRequest($"Superpoder com Id {id} não existe.");

                heroi.HeroisSuperpoderes.Add(new HeroiSuperpoder
                {
                    SuperpoderId = id,
                    Heroi = heroi
                });
            }

            _context.Herois.Add(heroi);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHeroi), new { id = heroi.Id }, heroi);
        }

        // PUT: api/herois/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> PutHeroi(int id, HeroiUpdateDto dto)
        {
            var heroi = await _context.Herois
                .Include(h => h.HeroisSuperpoderes)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (heroi == null)
                return NotFound($"Herói com ID {id} não encontrado.");

            // Atualiza os dados do herói
            heroi.Nome = dto.Nome;
            heroi.NomeHeroi = dto.NomeHeroi;
            heroi.DataNascimento = dto.DataNascimento;
            heroi.Altura = dto.Altura;
            heroi.Peso = dto.Peso;

            // Atualiza os superpoderes
            heroi.HeroisSuperpoderes.Clear(); // Remove os superpoderes atuais

            foreach (var idSuperpoder in dto.SuperpoderesIds)
            {
                if (!_context.Superpoderes.Any(s => s.Id == idSuperpoder))
                    return BadRequest($"Superpoder com ID {idSuperpoder} não existe.");

                heroi.HeroisSuperpoderes.Add(new HeroiSuperpoder
                {
                    SuperpoderId = idSuperpoder,
                    Heroi = heroi
                });
            }

            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            return NoContent(); // Retorna 204 No Content para indicar que a atualização foi bem-sucedida
        }

    } // <-- Fechamento da classe HeroisController
}
