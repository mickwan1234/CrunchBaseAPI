using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrunchBaseAPITest.Models;

namespace CrunchBaseAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustryListsController : ControllerBase
    {
        private readonly CrunchBaseContext _context;

        public IndustryListsController(CrunchBaseContext context)
        {
            _context = context;
        }

        // GET: api/IndustryLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndustryList>>> GetIndustryList()
        {
            return await _context.IndustryList.ToListAsync();
        }

        // GET: api/IndustryLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IndustryList>> GetIndustryList(int id)
        {
            var industryList = await _context.IndustryList.FindAsync(id);

            if (industryList == null)
            {
                return NotFound();
            }

            return industryList;
        }

        // PUT: api/IndustryLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndustryList(int id, IndustryList industryList)
        {
            if (id != industryList.Id)
            {
                return BadRequest();
            }

            _context.Entry(industryList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndustryListExists(id))
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

        // POST: api/IndustryLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IndustryList>> PostIndustryList(IndustryList industryList)
        {
            _context.IndustryList.Add(industryList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndustryList", new { id = industryList.Id }, industryList);
        }

        // DELETE: api/IndustryLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IndustryList>> DeleteIndustryList(int id)
        {
            var industryList = await _context.IndustryList.FindAsync(id);
            if (industryList == null)
            {
                return NotFound();
            }

            _context.IndustryList.Remove(industryList);
            await _context.SaveChangesAsync();

            return industryList;
        }

        private bool IndustryListExists(int id)
        {
            return _context.IndustryList.Any(e => e.Id == id);
        }
    }
}
