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
    public class AtributosValorController : ApiController
    {
        private SistemaInventario_Context db = new SistemaInventario_Context();

        // GET: api/AtributosValor
        public IQueryable<AtributoValor> GetAtributoValors()
        {
            return db.AtributoValors;
        }

        // GET: api/AtributosValor/5
        [ResponseType(typeof(AtributoValor))]
        public IHttpActionResult GetAtributoValor(int id)
        {
            AtributoValor atributoValor = db.AtributoValors.Find(id);
            if (atributoValor == null)
            {
                return NotFound();
            }

            return Ok(atributoValor);
        }

        // PUT: api/AtributosValor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtributoValor(int id, AtributoValor atributoValor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != atributoValor.Id)
            {
                return BadRequest();
            }

            db.Entry(atributoValor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtributoValorExists(id))
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

        // POST: api/AtributosValor
        [ResponseType(typeof(AtributoValor))]
        public IHttpActionResult PostAtributoValor(AtributoValor atributoValor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AtributoValors.Add(atributoValor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = atributoValor.Id }, atributoValor);
        }

        // DELETE: api/AtributosValor/5
        [ResponseType(typeof(AtributoValor))]
        public IHttpActionResult DeleteAtributoValor(int id)
        {
            AtributoValor atributoValor = db.AtributoValors.Find(id);
            if (atributoValor == null)
            {
                return NotFound();
            }

            db.AtributoValors.Remove(atributoValor);
            db.SaveChanges();

            return Ok(atributoValor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AtributoValorExists(int id)
        {
            return db.AtributoValors.Count(e => e.Id == id) > 0;
        }
    }
}