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
using Immigration.Models;

namespace Immigration.Controllers
{
    public class CustomerVisaGotsController : ApiController
    {
        private ImmigrationEntities db = new ImmigrationEntities();

        // GET: api/CustomerVisaGots
        public IQueryable<CustomerVisaGot> GetCustomerVisaGots()
        {
            return db.CustomerVisaGots;
        }

        // GET: api/CustomerVisaGots/5
        [ResponseType(typeof(CustomerVisaGot))]
        public IHttpActionResult GetCustomerVisaGot(int id)
        {
            CustomerVisaGot customerVisaGot = db.CustomerVisaGots.Find(id);
            if (customerVisaGot == null)
            {
                return NotFound();
            }

            return Ok(customerVisaGot);
        }

        // PUT: api/CustomerVisaGots/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerVisaGot(int id, CustomerVisaGot customerVisaGot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerVisaGot.ID)
            {
                return BadRequest();
            }

            db.Entry(customerVisaGot).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerVisaGotExists(id))
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

        // POST: api/CustomerVisaGots
        [ResponseType(typeof(CustomerVisaGot))]
        public IHttpActionResult PostCustomerVisaGot(CustomerVisaGot customerVisaGot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerVisaGots.Add(customerVisaGot);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerVisaGot.ID }, customerVisaGot);
        }

        // DELETE: api/CustomerVisaGots/5
        [ResponseType(typeof(CustomerVisaGot))]
        public IHttpActionResult DeleteCustomerVisaGot(int id)
        {
            CustomerVisaGot customerVisaGot = db.CustomerVisaGots.Find(id);
            if (customerVisaGot == null)
            {
                return NotFound();
            }

            db.CustomerVisaGots.Remove(customerVisaGot);
            db.SaveChanges();

            return Ok(customerVisaGot);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerVisaGotExists(int id)
        {
            return db.CustomerVisaGots.Count(e => e.ID == id) > 0;
        }
    }
}