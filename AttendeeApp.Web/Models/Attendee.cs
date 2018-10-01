using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendeeApp.Web.Models
{
    public class Attendee
    {
        [Key]
        [Column(Order = 0)]
        public Guid AttendeeId { get; set; }

        [Column(Order = 1)]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column(Order = 2)]
        [MaxLength(255)]
        public string Email { get; set; }
    }
}