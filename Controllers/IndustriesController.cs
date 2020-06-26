﻿using System;
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
    public class IndustriesController : ControllerBase
    {
        private readonly CrunchBaseContext _context;

        public IndustriesController(CrunchBaseContext context)
        {
            _context = context;
        }

        // GET: api/Industries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Industry>>> GetIndustry()
        {
            return await _context.Industry.ToListAsync();
        }

        // GET: api/Industries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Industry>> GetIndustry(int id)
        {
            var industry = await _context.Industry.FindAsync(id);

            if (industry == null)
            {
                return NotFound();
            }

            return industry;
        }

        // PUT: api/Industries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndustry(int id, Industry industry)
        {
            if (id != industry.Id)
            {
                return BadRequest();
            }

            _context.Entry(industry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndustryExists(id))
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

        // POST: api/Industries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Industry>> PostIndustry(Industry industry)
        {
            _context.Industry.Add(industry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIndustry", new { id = industry.Id }, industry);
        }

        // DELETE: api/Industries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Industry>> DeleteIndustry(int id)
        {
            var industry = await _context.Industry.FindAsync(id);
            if (industry == null)
            {
                return NotFound();
            }

            _context.Industry.Remove(industry);
            await _context.SaveChangesAsync();

            return industry;
        }

        private bool IndustryExists(int id)
        {
            return _context.Industry.Any(e => e.Id == id);
        }
    }
}
