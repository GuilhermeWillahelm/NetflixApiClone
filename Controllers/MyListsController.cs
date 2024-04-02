using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetflixApiClone.Data;
using NetflixApiClone.Models;

namespace NetflixApiClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyListsController : ControllerBase
    {
        private readonly NetflixApiContext _context;

        public MyListsController(NetflixApiContext context)
        {
            _context = context;
        }

        // GET: api/MyLists
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<MyList>>> GetMyList()
        {
            return await _context.MyList.ToListAsync();
        }

        // GET: api/MyLists/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<MyList>> GetMyList(int id)
        {
            var myList = await _context.MyList.FindAsync(id);

            if (myList == null)
            {
                return NotFound();
            }

            return myList;
        }

        // PUT: api/MyLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutMyList(int id, MyList myList)
        {
            if (id != myList.Id)
            {
                return BadRequest();
            }

            _context.Entry(myList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyListExists(id))
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

        // POST: api/MyLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<MyList>> PostMyList(MyList myList)
        {
            _context.MyList.Add(myList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyList", new { id = myList.Id }, myList);
        }

        // DELETE: api/MyLists/5
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteMyList(int id)
        {
            var myList = await _context.MyList.FindAsync(id);
            if (myList == null)
            {
                return NotFound();
            }

            _context.MyList.Remove(myList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyListExists(int id)
        {
            return _context.MyList.Any(e => e.Id == id);
        }
    }
}
