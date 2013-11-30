using Resources;
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
				// Add a contact.
				_entities.uspAddContactEF(contact.FirstName, contact.LastName, contact.EmailAddress);
			}
			catch
			{
				// Throw exception with set message.
				throw new Exception(Messages.AddContactError);
			}
		}

		// Delete a contact.
		public void Delete(Contact contact)
		{
			try
			{
				// Remove a Contact from our repository.
				_entities.uspRemoveContact(contact.ContactID);
			}

			catch
			{
				// Throw exception with set message.
				throw new Exception(Messages.DeleteContactError);
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
				// Returns all contacts available.
				return _entities.Contacts;
			}

			catch
			{
				// Throw exception with set message.
				throw new Exception(Messages.GetAllContactsError);
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
				// Throw exception with set message.
				throw new Exception(Messages.GetContactError);
			}
		}

		// Get the last contacts with default offset of 20.
		public List<Contact> GetLastContacts(int count = 20)
		{
			try
			{
				// Returns the Contacts with the set offset limit.
				return _entities.Contacts.Take(count).ToList();
			}

			catch
			{
				// Throw exception with set message.
				throw new Exception(String.Format(Messages.GetContactsWithOffsetError, count));
			}
		}

		// Saves everything to db.
		public void Save()
		{
			try
			{
				// Save changes.
				_entities.SaveChanges();
			}

			catch
			{
				// Throw exception with set message.
				throw new Exception(Messages.SaveContactsError);
			}
		}

		// Updates a contact.
		public void Update(Contact contact)
		{
			try
			{
				// Update a contact with new data.
				_entities.uspUpdateContact(contact.ContactID, contact.FirstName, contact.LastName, contact.EmailAddress);
			}

			catch
			{
				// Throw exception with set message.
				throw new Exception(Messages.UpdateContactError);
			}
		}
	}
} 