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
    public class EpisodesController : ControllerBase
    {
        private readonly NetflixApiContext _context;
        private readonly IMapper _mapper;

        public EpisodesController(NetflixApiContext context)
        {
            _context = context;
        }

        // GET: api/Episodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpisodeDto>>> GetEpisodes()
        {
            return await _context.Episodes.Select(e => ItemToDto(e)).ToListAsync();
        }

        // GET: api/Episodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EpisodeDto>> GetEpisode(int id)
        {
            var episode = await _context.Episodes.FindAsync(id);

            if (episode == null)
            {
                return NotFound();
            }

            return ItemToDto(episode);
        }

        // PUT: api/Episodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEpisode(int id, EpisodeDto episodeDto)
        {
            if (id != episodeDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(episodeDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpisodeExists(id))
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

        // POST: api/Episodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EpisodeDto>> PostEpisode(EpisodeDto episodeDto)
        {
            var episode = _mapper.Map<Episode>(episodeDto);
            _context.Episodes.Add(episode);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(episode), new { id = episode.Id }, episode);
        }

        // DELETE: api/Episodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpisode(int id)
        {
            var episode = await _context.Episodes.FindAsync(id);
            if (episode == null)
            {
                return NotFound();
            }

            _context.Episodes.Remove(episode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EpisodeExists(int id)
        {
            return _context.Episodes.Any(e => e.Id == id);
        }

        public static EpisodeDto ItemToDto(Episode episode) =>
            new EpisodeDto 
            {
                Id = episode.Id,
                Title = episode.Title,
                ContentEpisode = episode.ContentEpisode,
                EpisodeNumber = episode.EpisodeNumber,
                SeriesId = episode.SeriesId,
                SeriesDto = new SeriesDto
                {
                    Id = episode.Series.Id,
                    Title = episode.Series.Title,
                    Rating = episode.Series.Rating,
                    ReleaseDate = episode.Series.ReleaseDate,
                    ThumbSeries = episode.Series.ThumbSeries
                }
            };
    }
}
