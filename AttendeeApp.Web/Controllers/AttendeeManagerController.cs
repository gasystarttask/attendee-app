using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AttendeeApp.Core.Interface;
using AttendeeApp.Web.Models;

namespace AttendeeApp.Web.Controllers
{
    public class AttendeeManagerController : Controller
    {
        private readonly IUnitOfWork _db;

        public AttendeeManagerController(IUnitOfWork db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
          
            var attendees = Mapper.MapAttendeeCollection(_db.Attendees.GetAll());
            

            return View(attendees.ToList());
        }

        // GET
        public ActionResult Add()
        {
            return
            View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "AttendeeId,Name,Email")] Attendee attendee)
        {
            
            if (ModelState.IsValid)
            {
                attendee.AttendeeId = Guid.NewGuid();
                _db.Attendees.Add(Mapper.ReverseMapAttendee(attendee));
                _db.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(Guid attendeeid)
        {
            var attandee = _db.Attendees.Get(attendeeid);
            if (attandee == null)
            {
                Response.Write("Formulaire ID n'existe pas.");
                return null;
            }

            return View(Mapper.MapAttendee(attandee));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([Bind(Include = "AttendeeId,Name,Email")] Attendee attendee)
        {
            _db.Attendees.Remove(Mapper.ReverseMapAttendee(attendee));
            await _db.CommitAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid attendeeid)
        {
            var attendee = _db.Attendees.Get(attendeeid);

            if (attendee == null)
            {
                Response.Write("Formulaire ID n'existe pas.");
                return null;
            }

            return View(Mapper.MapAttendee(attendee));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttendeeId,Name,Email")] Attendee attendee)
        {

            if (ModelState.IsValid)
            {
                _db.Attendees.Update(Mapper.ReverseMapAttendee(attendee));
                _db.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(Guid attendeeid)
        {
            var attendee = _db.Attendees.Get(attendeeid);
            if (attendee == null)
            {
                Response.Write("Formulaire ID n'existe pas.");
                return null;
            }

            return View(Mapper.MapAttendee(attendee));
        }
    }
}