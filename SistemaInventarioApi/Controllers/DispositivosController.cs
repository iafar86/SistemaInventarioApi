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
    public class DispositivosController : ApiController
    {
        private SistemaInventario_Context db = new SistemaInventario_Context();

        // GET: api/Dispositivos
        public IQueryable<Dispositivo> GetDispositivoes()
        {
            return db.Dispositivoes;
        }

        // GET: api/Dispositivos/5
        [ResponseType(typeof(Dispositivo))]
        public IHttpActionResult GetDispositivo(int id)
        {
            Dispositivo dispositivo = db.Dispositivoes.Find(id);
            if (dispositivo == null)
            {
                return NotFound();
            }

            return Ok(dispositivo);
        }

        // PUT: api/Dispositivos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDispositivo(int id, Dispositivo dispositivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dispositivo.Id)
            {
                return BadRequest();
            }

            db.Entry(dispositivo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DispositivoExists(id))
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

        // POST: api/Dispositivos
        [ResponseType(typeof(Dispositivo))]
        public IHttpActionResult PostDispositivo(Dispositivo dispositivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dispositivoes.Add(dispositivo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dispositivo.Id }, dispositivo);
        }

        // DELETE: api/Dispositivos/5
        [ResponseType(typeof(Dispositivo))]
        public IHttpActionResult DeleteDispositivo(int id)
        {
            Dispositivo dispositivo = db.Dispositivoes.Find(id);
            if (dispositivo == null)
            {
                return NotFound();
            }

            db.Dispositivoes.Remove(dispositivo);
            db.SaveChanges();

            return Ok(dispositivo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DispositivoExists(int id)
        {
            return db.Dispositivoes.Count(e => e.Id == id) > 0;
        }
    }
}