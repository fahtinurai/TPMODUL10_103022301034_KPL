using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD10_103022300134.Models;
using System.Collections.Generic;

namespace MOD10_103022300134.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "LeBron James", Nim = "1302000001" },
            new Mahasiswa { Nama = "Stephen Curry", Nim = "1302000002" }
        };

        // GET: api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> Get()
        {
            return mahasiswaList;
        }

        // GET: api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> Get(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound();
            }
            return mahasiswaList[index];
        }

        // POST: api/mahasiswa
        [HttpPost]
        public ActionResult Post([FromBody] Mahasiswa mhs)
        {
            mahasiswaList.Add(mhs);
            return Ok();
        }

        // DELETE: api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound();
            }
            mahasiswaList.RemoveAt(index);
            return Ok();
        }
    }
}
