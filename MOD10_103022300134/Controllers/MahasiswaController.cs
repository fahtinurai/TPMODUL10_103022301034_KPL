using Microsoft.AspNetCore.Mvc;
using MOD10_103022300134.Data;
using MOD10_103022300134.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace MOD10_103022300134.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MahasiswaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mahasiswa>>> GetMahasiswas()
        {
            return await _context.Mahasiswas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mahasiswa>> GetMahasiswa(int id)
        {
            var mahasiswa = await _context.Mahasiswas.FindAsync(id);

            if (mahasiswa == null)
            {
                return NotFound();
            }

            return mahasiswa;
        }

        [HttpPost]
        public async Task<ActionResult<Mahasiswa>> PostMahasiswa(Mahasiswa mahasiswa)
        {
            _context.Mahasiswas.Add(mahasiswa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMahasiswa), new { id = mahasiswa.Id }, mahasiswa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMahasiswa(int id, Mahasiswa mahasiswa)
        {
            if (id != mahasiswa.Id)
            {
                return BadRequest();
            }

            _context.Entry(mahasiswa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MahasiswaExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMahasiswa(int id)
        {
            var mahasiswa = await _context.Mahasiswas.FindAsync(id);
            if (mahasiswa == null)
            {
                return NotFound();
            }

            _context.Mahasiswas.Remove(mahasiswa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MahasiswaExists(int id)
        {
            return _context.Mahasiswas.Any(e => e.Id == id);
        }
    }
}
