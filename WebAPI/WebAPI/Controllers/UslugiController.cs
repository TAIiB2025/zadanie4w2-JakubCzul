using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UslugiController : ControllerBase
    {
        private static List<Usluga> _lista = new()
        {
            new Usluga { Id = 1, Nazwa = "Malowanie ścian", Wykonawca = "Jan Kowalski", Rodzaj = "Budowlana", Rok = 2023 },
            new Usluga { Id = 2, Nazwa = "Naprawa laptopa", Wykonawca = "TechFix Serwis", Rodzaj = "Elektroniczna", Rok = 2024 },
            new Usluga { Id = 3, Nazwa = "Projekt ogrodu", Wykonawca = "Zielony Zakątek", Rodzaj = "Projektowa", Rok = 2022 },
            new Usluga { Id = 4, Nazwa = "Tłumaczenie dokumentów", Wykonawca = "Anna Nowak", Rodzaj = "Językowa", Rok = 2021 },
            new Usluga { Id = 5, Nazwa = "Kurs programowania", Wykonawca = "CodeAcademy", Rodzaj = "Edukacyjna", Rok = 2025 }
        };

        private static int _idGen = 6;

        [HttpGet]
        public ActionResult<IEnumerable<Usluga>> Get() => Ok(_lista);

        [HttpGet("{id}")]
        public ActionResult<Usluga> GetById(int id)
        {
            var usluga = _lista.FirstOrDefault(u => u.Id == id);
            return usluga is null ? NotFound() : Ok(usluga);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Usluga usluga)
        {
            usluga.Id = _idGen++;
            _lista.Add(usluga);
            return CreatedAtAction(nameof(GetById), new { id = usluga.Id }, usluga);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Usluga updated)
        {
            var usluga = _lista.FirstOrDefault(u => u.Id == id);
            if (usluga is null) return NotFound();

            usluga.Nazwa = updated.Nazwa;
            usluga.Wykonawca = updated.Wykonawca;
            usluga.Rodzaj = updated.Rodzaj;
            usluga.Rok = updated.Rok;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var usluga = _lista.FirstOrDefault(u => u.Id == id);
            if (usluga is null) return NotFound();

            _lista.Remove(usluga);
            return NoContent();
        }
    }
}
