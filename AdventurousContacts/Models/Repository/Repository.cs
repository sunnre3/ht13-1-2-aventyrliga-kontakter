using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models.Repository
{
	public class Repository : IRepository
	{
		// Keeps track on whether the resources
		// has been disposed or not.
		private bool _disposed = false;

		// Our EF entities.
		private AdventureWorksEntities _entities = new AdventureWorksEntities();

		// Add a contact.
		public void Add(Contact contact)
		{
			try
			{
				_entities.uspAddContactEF(contact.FirstName, contact.LastName, contact.EmailAddress);
			}
			catch
			{
				throw new Exception("Ett fel inträffades vid tilläggning av kontakt.");
			}
		}

		// Delete a contact.
		public void Delete(Contact contact)
		{
			try
			{
				_entities.uspRemoveContact(contact.ContactID);
			}

			catch
			{
				throw new Exception("Ett fel inträffades vid borttagning av kontakt.");
			}
		}

		// Dispose resources.
		public void Dispose()
		{
			Dispose(true);
		}

		// Does the actual disposing.
		protected virtual void Dispose(bool disposing)
		{
			// If not yet disposed.
			if (!_disposed)
			{
				// And if we're disposing...
				if (disposing)
				{
					// Dispose EF.
					_entities.Dispose();
				}
			}

			// Set disposed to true.
			_disposed = true;
		}

		// Returns all contacts.
		public IQueryable<Contact> FindAllContacts()
		{
			try
			{
				return _entities.Contacts;
			}

			catch
			{
				throw new Exception("Ett fel inträffades vid hämtning av alla kontakter.");
			}
		}

		// Get one Contact object by Id.
		public Contact GetContactById(int contactId)
		{
			try
			{
				// Try getting the contact.
				var contact = _entities.uspGetContact(contactId).FirstOrDefault();

				return new Contact {
						ContactID = contact.ContactID,
						FirstName = contact.FirstName,
						LastName = contact.LastName,
						EmailAddress = contact.EmailAddress
					};
			}

			catch
			{
				throw new Exception("Ett fel inträffades vid hämtning av kontakt.");
			}
		}

		// Get the last contacts with default offset of 20.
		public List<Contact> GetLastContacts(int count = 20)
		{
			try
			{
				return _entities.Contacts.Take(count).ToList();
			}

			catch
			{
				throw new Exception(String.Format("Ett fel inträffades vid hämtning av sista {0} kontakterna.", count));
			}
		}

		// Saves everything to db.
		public void Save()
		{
			try
			{
				_entities.SaveChanges();
			}

			catch
			{
				throw new Exception("Ett fel inträffades vid sparning av kontaktlistan.");
			}
		}

		// Updates a contact.
		public void Update(Contact contact)
		{
			try
			{
				_entities.uspUpdateContact(contact.ContactID, contact.FirstName, contact.LastName, contact.EmailAddress);
			}

			catch
			{
				throw new Exception("Ett fel inträffades vid uppdatering av kontakt.");
			}
		}
	}
} 