using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_ProyectoFinal_Progra6_SebastianSancho.Models;

namespace API_ProyectoFinal_Progra6_SebastianSancho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblMiembroController : ControllerBase
    {
        private readonly ProyectoProgra6Context _context;

        public TblMiembroController(ProyectoProgra6Context context)
        {
            _context = context;
        }

        // GET: api/TblMiembro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblMiembro>>> GetTblMiembros()
        {
            return await _context.TblMiembros.ToListAsync();
        }

        // GET: api/TblMiembro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblMiembro>> GetTblMiembro(int id)
        {
            var tblMiembro = await _context.TblMiembros.FindAsync(id);

            if (tblMiembro == null)
            {
                return NotFound();
            }

            return tblMiembro;
        }

        // PUT: api/TblMiembro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblMiembro(int id, TblMiembro tblMiembro)
        {
            if (id != tblMiembro.MiembroId)
            {
                return BadRequest();
            }

            _context.Entry(tblMiembro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMiembroExists(id))
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

        // POST: api/TblMiembro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblMiembro>> PostTblMiembro(TblMiembro tblMiembro)
        {
            _context.TblMiembros.Add(tblMiembro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblMiembro", new { id = tblMiembro.MiembroId }, tblMiembro);
        }

        // DELETE: api/TblMiembro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblMiembro(int id)
        {
            var tblMiembro = await _context.TblMiembros.FindAsync(id);
            if (tblMiembro == null)
            {
                return NotFound();
            }

            _context.TblMiembros.Remove(tblMiembro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblMiembroExists(int id)
        {
            return _context.TblMiembros.Any(e => e.MiembroId == id);
        }
    }
}
