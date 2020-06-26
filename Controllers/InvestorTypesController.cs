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
    public class InvestorTypesController : ControllerBase
    {
        private readonly CrunchBaseContext _context;

        public InvestorTypesController(CrunchBaseContext context)
        {
            _context = context;
        }

        // GET: api/InvestorTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvestorType>>> GetInvestorType()
        {
            return await _context.InvestorType.ToListAsync();
        }

        // GET: api/InvestorTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvestorType>> GetInvestorType(int id)
        {
            var investorType = await _context.InvestorType.FindAsync(id);

            if (investorType == null)
            {
                return NotFound();
            }

            return investorType;
        }

        // PUT: api/InvestorTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestorType(int id, InvestorType investorType)
        {
            if (id != investorType.Id)
            {
                return BadRequest();
            }

            _context.Entry(investorType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestorTypeExists(id))
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

        // POST: api/InvestorTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InvestorType>> PostInvestorType(InvestorType investorType)
        {
            _context.InvestorType.Add(investorType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvestorType", new { id = investorType.Id }, investorType);
        }

        // DELETE: api/InvestorTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvestorType>> DeleteInvestorType(int id)
        {
            var investorType = await _context.InvestorType.FindAsync(id);
            if (investorType == null)
            {
                return NotFound();
            }

            _context.InvestorType.Remove(investorType);
            await _context.SaveChangesAsync();

            return investorType;
        }

        private bool InvestorTypeExists(int id)
        {
            return _context.InvestorType.Any(e => e.Id == id);
        }
    }
}
