using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetflixApiClone.Data;
using NetflixApiClone.Dtos;
using NetflixApiClone.Models;

namespace NetflixApiClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly NetflixApiContext _context;
        private readonly IMapper _mapper;

        public SeriesController(NetflixApiContext context)
        {
            _context = context;
        }

        // GET: api/Series
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeriesDto>>> GetSeries()
        {
            return await _context.Series.Select(s => ItemToDto(s)).ToListAsync();
        }

        // GET: api/Series/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeriesDto>> GetSeries(int id)
        {
            var series = await _context.Series.FindAsync(id);

            if (series == null)
            {
                return NotFound();
            }

            return ItemToDto(series);
        }

        // PUT: api/Series/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeries(int id, SeriesDto seriesDto)
        {
            if (id != seriesDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(seriesDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeriesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Series
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeriesDto>> PostSeries(SeriesDto seriesDto)
        {
            var series = _mapper.Map<Series>(seriesDto);
            _context.Series.Add(series);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeries", new { id = series.Id }, series);
        }

        // DELETE: api/Series/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            var series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return NotFound();
            }

            _context.Series.Remove(series);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeriesExists(int id)
        {
            return _context.Series.Any(e => e.Id == id);
        }

        public static SeriesDto ItemToDto(Series series) =>
            new SeriesDto
            {
                Id = series.Id,
                Title = series.Title,
                ThumbSeries = series.ThumbSeries,
                ReleaseDate = series.ReleaseDate,
                Rating = series.Rating,
                GenreDto = new GenreDto
                {
                    Id = series.Genre.Id,
                    Name = series.Genre.Name,
                },
                EpisodeDtos = (ICollection<EpisodeDto>)series.Episodes
                
            };
    }
}
