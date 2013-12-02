using AdventurousContacts.Models;
using AdventurousContacts.Models.Repository;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdventurousContacts.Controllers
{
    public class ContactController : Controller
    {
		// Private representation of the repository.
		private IRepository _repository;

		// Empty parameterless constructor to inject dependencies.
		public ContactController()
			:this(new Repository())
		{

		}

		// Initiates the repository.
		public ContactController(IRepository repository)
		{
			_repository = repository;
		}

		//
		// GET: /Contact/Create/
		public ActionResult Create()
		{
			return View("Create");
		}

		//
		// POST: /Contact/Create/
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Exclude="ContactID")]Contact contact)
		{
			if (ModelState.IsValid)
			{
				try
				{
					// Add the new Contact to the repository.
					_repository.Add(contact);

					// Save changes.
					_repository.Save();

					// Show success page.
					return View("Success", contact);
				}

				// If the model is valid and we still encounter an error therew
				// was some problem with the repository and we'll add an unknown
				// error to the modelstate.
				catch
				{
					ModelState.AddModelError(String.Empty, Messages.UnknownError);
				}
			}

			// Return Create view.
			return View("Create", contact);
		}

		//
		// GET: /Contact/Delete/contactId
		public ActionResult Delete(int id = 0)
		{
			// Get the contact associated with the id.
			var contact = _repository.GetContactById(id);

			// If no contact was found, show the
			// NotFound view.
			if (contact == null)
			{
				return View("NotFound");
			}

			// Return the edit view along with
			// the Contact object for user to edit.
			return View("Delete", contact);
		}

		//
		// POST: /Contact/Delete/contactId
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id = 0)
		{
			try
			{
				// Get the contact associated with the id.
				var contact = _repository.GetContactById(id);

				// Delete the contact.
				_repository.Delete(contact);

				// Save changes.
				_repository.Save();

				// Return Success view.
				return View("Success", contact);
			}

			catch
			{
				// If no contact was found, add an error
				// to the modelstate.
				ModelState.AddModelError(String.Empty, Messages.DeleteContactError);
			}

			return View("Delete", _repository.GetContactById(id));
		}

		// Dispose of resources.
		protected override void Dispose(bool disposing)
		{
			_repository.Dispose();
			base.Dispose(disposing);
		}

		//
		// GET: /Contact/Edit/contactId
		public ActionResult Edit(int id = 0)
		{
			// Get the contact associated with the id.
			var contact = _repository.GetContactById(id);

			// If no contact was found, show the
			// NotFound view.
			if (contact == null)
			{
				return View("NotFound");
			}

			// Return the edit view along with
			// the Contact object for user to edit.
			return View("Edit", contact);
		}

		//
		// POST: /Contact/Edit/contactId
		[HttpPost]
		public ActionResult Edit(Contact contact)
		{
			if (ModelState.IsValid)
			{
				try
				{
					// Update thge repository with
					// the newly edited Contact.
					_repository.Update(contact);

					// Save changes.
					_repository.Save();

					// Return the Success view.
					return View("Success", contact);
				}

				catch
				{
					// If no contact was found, add an error
					// to the modelstate.
					ModelState.AddModelError(String.Empty, Messages.UpdateContactError);
				}
			}

			return View("Edit", contact);
		}

        //
        // GET: /Contact/
        public ActionResult Index()
        {
			// Get the last 20 contacts.
			var contacts = _repository.GetLastContacts();

			// Return the view with the contacts.
            return View("Index", contacts);
        }

    }
}
