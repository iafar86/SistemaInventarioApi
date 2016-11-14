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
    public class TipoDispositivosController : ApiController
    {
        private SistemaInventario_Context db = new SistemaInventario_Context();

        // GET: api/TipoDispositivos
        public IQueryable<TipoDispositivo> GetTipoDispositivoes()
        {
            return db.TipoDispositivoes;
        }

        // GET: api/TipoDispositivos/5
        [ResponseType(typeof(TipoDispositivo))]
        public IHttpActionResult GetTipoDispositivo(int id)
        {
            TipoDispositivo tipoDispositivo = db.TipoDispositivoes.Find(id);
            if (tipoDispositivo == null)
            {
                return NotFound();
            }

            return Ok(tipoDispositivo);
        }

        // PUT: api/TipoDispositivos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoDispositivo(int id, TipoDispositivo tipoDispositivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoDispositivo.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoDispositivo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDispositivoExists(id))
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

        // POST: api/TipoDispositivos
        [ResponseType(typeof(TipoDispositivo))]
        public IHttpActionResult PostTipoDispositivo(TipoDispositivo tipoDispositivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoDispositivoes.Add(tipoDispositivo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoDispositivo.Id }, tipoDispositivo);
        }

        // DELETE: api/TipoDispositivos/5
        [ResponseType(typeof(TipoDispositivo))]
        public IHttpActionResult DeleteTipoDispositivo(int id)
        {
            TipoDispositivo tipoDispositivo = db.TipoDispositivoes.Find(id);
            if (tipoDispositivo == null)
            {
                return NotFound();
            }

            db.TipoDispositivoes.Remove(tipoDispositivo);
            db.SaveChanges();

            return Ok(tipoDispositivo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoDispositivoExists(int id)
        {
            return db.TipoDispositivoes.Count(e => e.Id == id) > 0;
        }
    }
}