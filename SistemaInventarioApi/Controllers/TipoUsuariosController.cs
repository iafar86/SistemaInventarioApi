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
    public class TipoUsuariosController : ApiController
    {
        private SistemaInventario_Context db = new SistemaInventario_Context();

        // GET: api/TipoUsuarios
        public IQueryable<TipoUsuario> GetTipoUsuarios()
        {
            return db.TipoUsuarios;
        }

        // GET: api/TipoUsuarios/5
        [ResponseType(typeof(TipoUsuario))]
        public IHttpActionResult GetTipoUsuario(int id)
        {
            TipoUsuario tipoUsuario = db.TipoUsuarios.Find(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return Ok(tipoUsuario);
        }

        // PUT: api/TipoUsuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoUsuario(int id, TipoUsuario tipoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoUsuario.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoUsuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoUsuarioExists(id))
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

        // POST: api/TipoUsuarios
        [ResponseType(typeof(TipoUsuario))]
        public IHttpActionResult PostTipoUsuario(TipoUsuario tipoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoUsuarios.Add(tipoUsuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoUsuario.Id }, tipoUsuario);
        }

        // DELETE: api/TipoUsuarios/5
        [ResponseType(typeof(TipoUsuario))]
        public IHttpActionResult DeleteTipoUsuario(int id)
        {
            TipoUsuario tipoUsuario = db.TipoUsuarios.Find(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            db.TipoUsuarios.Remove(tipoUsuario);
            db.SaveChanges();

            return Ok(tipoUsuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoUsuarioExists(int id)
        {
            return db.TipoUsuarios.Count(e => e.Id == id) > 0;
        }
    }
}