using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models
{
	[MetadataType(typeof(Contact_Metadata))]
	public partial class Contact { }

	public class Contact_Metadata
	{
		[Required(ErrorMessageResourceType = typeof(Resources.Messages),
			ErrorMessageResourceName = "FirstNameRequiredError")]
		[MaxLength(50, ErrorMessageResourceType = typeof(Resources.Messages),
			ErrorMessageResourceName = "FieldMaxLengthError")]
		[EmailAddress(ErrorMessageResourceType = typeof(Resources.Messages),
			ErrorMessageResourceName = "EmailAddressError", ErrorMessage = null)]
		[DisplayName("Epostadress")]
		public string EmailAddress { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Messages),
			ErrorMessageResourceName = "LastNameRequiredError")]
		[MaxLength(50, ErrorMessageResourceType = typeof(Resources.Messages),
			ErrorMessageResourceName = "FieldMaxLengthError")]
		[DisplayName("Förstanamn")]
		public string FirstName { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Messages),
			ErrorMessageResourceName = "EmailAddressRequiredError")]
		[MaxLength(50, ErrorMessageResourceType = typeof(Resources.Messages),
			ErrorMessageResourceName = "FieldMaxLengthError")]
		[DisplayName("Efternamn")]
		public string LastName { get; set; }
	}
}