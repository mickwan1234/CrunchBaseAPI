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
    public class InvestmentStagesController : ControllerBase
    {
        private readonly CrunchBaseContext _context;

        public InvestmentStagesController(CrunchBaseContext context)
        {
            _context = context;
        }

        // GET: api/InvestmentStages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvestmentStages>>> GetInvestmentStages()
        {
            return await _context.InvestmentStages.ToListAsync();
        }

        // GET: api/InvestmentStages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvestmentStages>> GetInvestmentStages(int id)
        {
            var investmentStages = await _context.InvestmentStages.FindAsync(id);

            if (investmentStages == null)
            {
                return NotFound();
            }

            return investmentStages;
        }

        // PUT: api/InvestmentStages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestmentStages(int id, InvestmentStages investmentStages)
        {
            if (id != investmentStages.Id)
            {
                return BadRequest();
            }

            _context.Entry(investmentStages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestmentStagesExists(id))
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

        // POST: api/InvestmentStages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InvestmentStages>> PostInvestmentStages(InvestmentStages investmentStages)
        {
            _context.InvestmentStages.Add(investmentStages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvestmentStages", new { id = investmentStages.Id }, investmentStages);
        }

        // DELETE: api/InvestmentStages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvestmentStages>> DeleteInvestmentStages(int id)
        {
            var investmentStages = await _context.InvestmentStages.FindAsync(id);
            if (investmentStages == null)
            {
                return NotFound();
            }

            _context.InvestmentStages.Remove(investmentStages);
            await _context.SaveChangesAsync();

            return investmentStages;
        }

        private bool InvestmentStagesExists(int id)
        {
            return _context.InvestmentStages.Any(e => e.Id == id);
        }
    }
}
