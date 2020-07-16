using System;
using System.ComponentModel.DataAnnotations;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description too long!")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }


        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Number of attendees is required")]
        [Range(0, 100, ErrorMessage = "Please enter a number between 0 and 100000.")]
        public int NumOfAttendee { get; set; }


        public bool IsTrue { get { return true; } }

        [Compare("IsTrue", ErrorMessage = "An attendee must register.")]
        public bool RequireRegisteration { get; set; }
    }
}
