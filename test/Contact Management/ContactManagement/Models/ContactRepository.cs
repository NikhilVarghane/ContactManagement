using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ContactManagement.Models;

namespace ContactManagement.Models
{
    public class ContactRepository  // This layer isn't needed for this project.  I'm just showboating.
        : IDisposable
    {
        private ContactEntities db;

        public ContactRepository(ContactEntities db)
        {
            this.db = db;
        }

        public IEnumerable<Contact> All()
        {
            return this.db.Contacts;
        }

        public Contact Single(int id)
        {
            return this.Single(o => o.Id == id);
        }

        public Contact Single(Expression<Func<Contact, bool>> predicate)
        {
            return this.db.Contacts.Single(predicate);
        }

        public void Add(Contact entity)
        {
            this.db.Contacts.Add(entity);
        }

        public void Remove(Contact entity)
        {
            this.db.Contacts.Remove(entity);
        }

        public void Save()
        {
            this.db.SaveChanges();
        }

        public void Dispose()
        {
            if (db != null)
                db.Dispose();
        }
    }
}