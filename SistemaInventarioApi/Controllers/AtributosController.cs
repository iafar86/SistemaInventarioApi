using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SistemaInventarioApi.Models;

namespace SistemaInventarioApi.Controllers
{
    public class AtributosController : ApiController
    {
        private SistemaInventario_Context db = new SistemaInventario_Context();

        // GET: api/Atributos
        public IQueryable<Atributo> GetAtributoes()
        {
            return db.Atributoes;
        }

        // GET: api/Atributos/5
        [ResponseType(typeof(Atributo))]
        public IHttpActionResult GetAtributo(int id)
        {
            Atributo atributo = db.Atributoes.Find(id);
            if (atributo == null)
            {
                return NotFound();
            }

            return Ok(atributo);
        }

        // PUT: api/Atributos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtributo(int id, Atributo atributo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != atributo.Id)
            {
                return BadRequest();
            }

            db.Entry(atributo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtributoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Atributos
        [ResponseType(typeof(Atributo))]
        public IHttpActionResult PostAtributo(Atributo atributo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Atributoes.Add(atributo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = atributo.Id }, atributo);
        }

        // DELETE: api/Atributos/5
        [ResponseType(typeof(Atributo))]
        public IHttpActionResult DeleteAtributo(int id)
        {
            Atributo atributo = db.Atributoes.Find(id);
            if (atributo == null)
            {
                return NotFound();
            }

            db.Atributoes.Remove(atributo);
            db.SaveChanges();

            return Ok(atributo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AtributoExists(int id)
        {
            return db.Atributoes.Count(e => e.Id == id) > 0;
        }
    }
}