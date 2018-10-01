using System.Collections.Generic;


namespace AttendeeApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AttendeeApp.Infrastructure.Context.AttendeeAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AttendeeApp.Infrastructure.Context.AttendeeAppContext context)
        {
            var attendees = new List<Core.Model.Attendee>
            {
                new Core.Model.Attendee {Name = "John Doe", Email="john.doe@example.com", },
                new Core.Model.Attendee {Name = "Jean Dupon", Email="jean.dupon@example.com", }
            };
            attendees.ForEach(a =>  context.Attendees.AddOrUpdate(p => p.Email, a));
            context.SaveChanges();
        }
    }
}
