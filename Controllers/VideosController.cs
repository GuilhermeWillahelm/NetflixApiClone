using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetflixApiClone.Data;
using NetflixApiClone.Models;
using NetflixApiClone.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace NetflixApiClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly NetflixApiContext _context;
        private readonly IMapper _mapper;

        public VideosController(NetflixApiContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<VideoDto>>> GetMovies()
        {
            return await _context.Videos.Select(m => ItemToDto(m)).ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<VideoDto>> GetMovie(int id)
        {
            var movie = await _context.Videos.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return ItemToDto(movie);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutMovie(int id, VideoDto movieDto)
        {
            if (id != movieDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<VideoDto>> PostMovie(VideoDto movieDto)
        {
            var movie = _mapper.Map<Video>(movieDto);
            _context.Videos.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(movie), new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Videos.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Videos.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Videos.Any(e => e.Id == id);
        }

        public static Dtos.VideoDto ItemToDto(Video movie) =>
            new Dtos.VideoDto 
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Director = movie.Director,
                Rating = movie.Rating,
                ContentVideo = movie.ContentVideo,
                ThumbVideo = movie.ThumbVideo,
                Genre = movie.Genre,
                TypeVideo = movie.TypeVideo,
            }; 
    }
}
