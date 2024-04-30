using Microsoft.AspNetCore.Mvc;

namespace modul10_1302223136.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mahasiswa : ControllerBase
    {

        private static List<String> course = new List<String> { "PBO", "KPL" };
        private static List<MahasiswaModel> arrMahasiswa = new List<MahasiswaModel>
        {
            new MahasiswaModel("Benedict Arvin Indra Puteprasa", "1302223136", course, 2001),
            new MahasiswaModel("B", "1302", course, 2002),
            new MahasiswaModel("C", "1303", course, 2003),
            new MahasiswaModel("D", "1304", course, 2004)
        };

        [HttpGet]
        public IEnumerable<MahasiswaModel> Get()
        {
            return arrMahasiswa;
        }

        [HttpGet("{id}")]
        public ActionResult<MahasiswaModel> Get(int id)
        {
            if (id < 0 || id >= arrMahasiswa.Count)
            {
                return NotFound();
            }
            return arrMahasiswa[id];
        }

        [HttpPost]
        public IActionResult Post([FromBody] MahasiswaModel mahasiswa)
        {
            arrMahasiswa.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new { id = arrMahasiswa.IndexOf(mahasiswa) }, mahasiswa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= arrMahasiswa.Count)
            {
                return NotFound();
            }
            arrMahasiswa.RemoveAt(id);
            return NoContent();
        }

        public class MahasiswaModel
        {
            public string nama { get; set; }
            public string nim { get; set; }
            public List<String> course { get; set; }
            public int year { get; set; }

            public MahasiswaModel(string nama, string nim, List<String> course, int year)
            {
                this.nama = nama;
                this.nim = nim;
                this.course = course;
                this.year = year;
            }
        }
    }
}
