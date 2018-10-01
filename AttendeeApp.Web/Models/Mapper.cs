using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;

namespace AttendeeApp.Web.Models
{
    public class Mapper
    {
        public static Core.Model.Attendee ReverseMapAttendee(Attendee attendee)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Attendee, Core.Model.Attendee>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<Attendee, Core.Model.Attendee>(attendee);
        }

        public static Attendee MapAttendee(Core.Model.Attendee attendee)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Core.Model.Attendee, Attendee>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<Core.Model.Attendee, Attendee>(attendee);
        }

        public static ICollection<Attendee> MapAttendeeCollection(ICollection<Core.Model.Attendee> attendees)
        {
            ICollection<Attendee> dest = new Collection<Attendee>();

            foreach (var attendee in attendees)
            {
                dest.Add(MapAttendee(attendee));
            }

            return dest;
        }
    }
}