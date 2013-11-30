using AdventurousContacts.Models;
using AdventurousContacts.Models.Repository;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
		public ActionResult Create(Contact contact)
		{
			if (ModelState.IsValid)
			{
				try
				{
					// Add the new Contact to the repository.
					_repository.Add(contact);

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

			// Return front-page view.
			return View("Index");
		}

		//
		// GET: /Contact/Delete/contactId
		public ActionResult Delete(int id = 0)
		{
			try
			{
				// Get the contact associated with the id.
				var contact = _repository.GetContactById(id);

				// Return the contact down to the view
				// for user confirmation.
				return View("Delete", contact);
			}

			catch
			{
				// If no contact was found, add an error
				// to the modelstate.
				ModelState.AddModelError(String.Empty, Messages.ContactNotFoundError);
			}

			// Return NotFound.
			return View("NotFound");
		}

		//
		// POST: /Contact/Delete/contactId
		[HttpPost]
		public ActionResult DeleteConfirmed(int id = 0)
		{
			try
			{
				// Get the contact associated with the id.
				var contact = _repository.GetContactById(id);

				// Delete the contact.
				_repository.Delete(contact);

				// Return Success view.
				return View("Success", Messages.DeleteContactSuccess);
			}

			catch
			{
				// If no contact was found, add an error
				// to the modelstate.
				ModelState.AddModelError(String.Empty, Messages.ContactNotFoundError);
			}

			// Return NotFound.
			return View("NotFound");
		}

		//
		// GET: /Contact/Edit/contactId
		public ActionResult Edit(int id = 0)
		{
			try
			{
				// Get the contact associated with the id.
				var contact = _repository.GetContactById(id);

				// Return the edit view along with
				// the Contact object for user to edit.
				return View("Edit", contact);
			}

			catch
			{
				// If no contact was found, add an error
				// to the modelstate.
				ModelState.AddModelError(String.Empty, Messages.ContactNotFoundError);
			}

			// Return NotFound.
			return View("NotFound");
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

					// Return the Success view.
					return View("Success", Messages.UpdateContactSuccess);
				}

				catch
				{
					// If no contact was found, add an error
					// to the modelstate.
					ModelState.AddModelError(String.Empty, Messages.ContactNotFoundError);
				}

				// Return NotFound.
				return View("NotFound");
			}

			return View("Edit", contact);
		}

        //
        // GET: /Contact/
        public ActionResult Index()
        {
            return View("Index");
        }

    }
}
