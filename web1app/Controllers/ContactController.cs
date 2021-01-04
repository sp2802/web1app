using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using web1app.Models;

namespace web1app.Controllers
{
    public class ContactController : ApiController
    {
        Contact[] contacts = new Contact[]
        {
new Contact(){Id=0,FirstName="Shailja",LastName="Pandey"},
new Contact(){Id=1,FirstName="Prachi",LastName="Mittal"},
new Contact(){Id=2,FirstName="Neha",LastName="Pande"}


        };







        // GET: api/Contact
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET: api/Contact/5
        public IHttpActionResult Get(int id)
        {
            Contact contact = contacts.FirstOrDefault(c => c.Id == id);
            if(contact == null)
             { 
                return NotFound(); 
             }
            return Ok(contact);
        }

        // POST: api/Contact
        public IEnumerable<Contact> Post([FromBody]Contact newContact)
        {
            List<Contact> contactList = contacts.ToList < Contact>();
            newContact.Id= contactList.Count;
            contactList.Add(newContact);
            contacts = contactList.ToArray();
            return contacts;
        }

        // PUT: api/Contact/5
        public IEnumerable<Contact> Put(int id, [FromBody]Contact updatedContact)
        {
            Contact contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                contact.FirstName = updatedContact.FirstName;
                contact.LastName = updatedContact.LastName;
                //or else contact=updatedContact;
            }
            return contacts;
        }

        // DELETE: api/Contact/5
        public IEnumerable<Contact> Delete(int id)
        {
            contacts = contacts.Where<Contact>(c => c.Id != id).ToArray<Contact>();
            return contacts;
        }
    }
}
