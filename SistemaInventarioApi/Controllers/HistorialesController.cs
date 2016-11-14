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
    public class HistorialesController : ApiController
    {
        private SistemaInventario_Context db = new SistemaInventario_Context();

        // GET: api/Historiales
        public IQueryable<Historial> GetHistorials()
        {
            return db.Historials;
        }

        // GET: api/Historiales/5
        [ResponseType(typeof(Historial))]
        public IHttpActionResult GetHistorial(int id)
        {
            Historial historial = db.Historials.Find(id);
            if (historial == null)
            {
                return NotFound();
            }

            return Ok(historial);
        }

        // PUT: api/Historiales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHistorial(int id, Historial historial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historial.Id)
            {
                return BadRequest();
            }

            db.Entry(historial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialExists(id))
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

        // POST: api/Historiales
        [ResponseType(typeof(Historial))]
        public IHttpActionResult PostHistorial(Historial historial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Historials.Add(historial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = historial.Id }, historial);
        }

        // DELETE: api/Historiales/5
        [ResponseType(typeof(Historial))]
        public IHttpActionResult DeleteHistorial(int id)
        {
            Historial historial = db.Historials.Find(id);
            if (historial == null)
            {
                return NotFound();
            }

            db.Historials.Remove(historial);
            db.SaveChanges();

            return Ok(historial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistorialExists(int id)
        {
            return db.Historials.Count(e => e.Id == id) > 0;
        }
    }
}