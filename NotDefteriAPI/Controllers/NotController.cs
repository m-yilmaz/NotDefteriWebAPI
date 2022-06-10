using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotDefteriAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotDefteriAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotController : ControllerBase
    {
        private readonly NotDbContext _db;

        public NotController(NotDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public List<Not> Get()
        {
            return (_db.Notlar.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Not> Get(int id)
        {
            Not not = _db.Notlar.Find(id);
            if (not == null) return NotFound();
            return not;
        }

        [HttpPost]
        public ActionResult<Not> Post(Not not)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (string.IsNullOrEmpty(not.Baslik))
                not.Baslik = "Başlıksız Not";
            _db.Notlar.Add(not);
            _db.SaveChanges();
            return not;
        }

        [HttpPut("{id}")]
        public ActionResult<Not> Put(int id, Not not)
        {
            if (id != not.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            not.GuncellemeTarihi = DateTime.Now;
            _db.Notlar.Update(not);
            _db.SaveChanges();
            return not;
        }

        [HttpDelete("{id}")]
        public ActionResult<Not> Delete(int id)
        {
            Not not = _db.Notlar.Find(id);
            if (not == null) return NotFound();
            _db.Notlar.Remove(not);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
