using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendeeApp.Core.Model
{
    public class Attendee : BaseEntity
    {
        public Attendee()
        {
            AttendeeId = Guid.NewGuid();
        }
        [Key]
        [Column(Order = 0)]
        public Guid AttendeeId { get; set; }

        [Column(Order = 1)]
        public string Name { get; set; }

        [Column(Order = 2)]
        public string Email { get; set; }
    }
}