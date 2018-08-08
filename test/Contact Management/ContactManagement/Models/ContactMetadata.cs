using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Models
{
    // I extended my auto-generated EF class to create new properties and apply metadata (field names and validation)

    [MetadataType(typeof(ContactMetadata))]
    public partial class Contact
    {

        /// <summary>
        /// Returns FirstName + MiddleInitial + LastName if they exist with spaces in between.
        /// </summary>
        public string FullName
        {
            get
            {
                // FirstName is guaranteed to not be null, but just in case things change later, I'm going to double-check for null values.
                var fullname = this.FirstName ?? "";  

                // append MI
                //fullname += String.IsNullOrWhiteSpace(this.MiddleInitial) ? "" : " " + this.MiddleInitial;

                // append LastName
                fullname += String.IsNullOrWhiteSpace(this.LastName) ? "" : " " + this.LastName;

                return fullname;
            }
        }
    }

    public class ContactMetadata
    {
        // this is the only required field right now
        [Required(ErrorMessage = "First Name is required"), DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required"), DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone No. is required"), DisplayName("Phone Number")]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email id is required"),  DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Status is required"), DisplayName("Status")]
        public Boolean Status { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get; set; }
    }
}