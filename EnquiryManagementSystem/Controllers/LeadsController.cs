using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnquiryManagementSystem;

namespace EnquiryManagementSystem.Controllers
{
    public class LeadsController : Controller
    {
        private EnquiryModelContainer db = new EnquiryModelContainer();

        // GET: Leads
        public async Task<ActionResult> Index()
        {
            var leads = db.Leads.Include(l => l.EnquiryType).Include(l => l.CustomerProfile).Include(l => l.SalesTeam).Include(l => l.Event).Include(l => l.Application).Include(l => l.User).Include(l => l.Advertisement);
            return View(await leads.ToListAsync());
        }

        // GET: Leads/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = await db.Leads.FindAsync(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        // GET: Leads/Create
        public ActionResult Create()
        {
            ViewBag.EnquiryTypeId = new SelectList(db.EnquiryTypes, "Id", "Name");
            ViewBag.CustomerProfileId = new SelectList(db.CustomerProfiles, "Id", "Name");
            ViewBag.SalesTeamId = new SelectList(db.SalesTeams, "Id", "Name");
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name");
            ViewBag.ApplicationId = new SelectList(db.Applications, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            ViewBag.AdvertisementId = new SelectList(db.Advertisements, "Id", "Name");
            return View();
        }

        // POST: Leads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CustomerName,FirmName,ContactNo,EmailId,City,State,EnquiryDate,Comments,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy,EnquiryTypeId,CustomerProfileId,SalesTeamId,EventId,ApplicationId,UserId,AdvertisementId,IsUrgent,IsQualify,IsDisQualify,IsDeactivate")] Lead lead)
        {
            if (ModelState.IsValid)
            {
                db.Leads.Add(lead);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EnquiryTypeId = new SelectList(db.EnquiryTypes, "Id", "Name", lead.EnquiryTypeId);
            ViewBag.CustomerProfileId = new SelectList(db.CustomerProfiles, "Id", "Name", lead.CustomerProfileId);
            ViewBag.SalesTeamId = new SelectList(db.SalesTeams, "Id", "Name", lead.SalesTeamId);
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", lead.EventId);
            ViewBag.ApplicationId = new SelectList(db.Applications, "Id", "Name", lead.ApplicationId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", lead.UserId);
            ViewBag.AdvertisementId = new SelectList(db.Advertisements, "Id", "Name", lead.AdvertisementId);
            return View(lead);
        }

        // GET: Leads/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = await db.Leads.FindAsync(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnquiryTypeId = new SelectList(db.EnquiryTypes, "Id", "Name", lead.EnquiryTypeId);
            ViewBag.CustomerProfileId = new SelectList(db.CustomerProfiles, "Id", "Name", lead.CustomerProfileId);
            ViewBag.SalesTeamId = new SelectList(db.SalesTeams, "Id", "Name", lead.SalesTeamId);
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", lead.EventId);
            ViewBag.ApplicationId = new SelectList(db.Applications, "Id", "Name", lead.ApplicationId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", lead.UserId);
            ViewBag.AdvertisementId = new SelectList(db.Advertisements, "Id", "Name", lead.AdvertisementId);
            return View(lead);
        }

        // POST: Leads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CustomerName,FirmName,ContactNo,EmailId,City,State,EnquiryDate,Comments,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy,EnquiryTypeId,CustomerProfileId,SalesTeamId,EventId,ApplicationId,UserId,AdvertisementId,IsUrgent,IsQualify,IsDisQualify,IsDeactivate")] Lead lead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lead).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EnquiryTypeId = new SelectList(db.EnquiryTypes, "Id", "Name", lead.EnquiryTypeId);
            ViewBag.CustomerProfileId = new SelectList(db.CustomerProfiles, "Id", "Name", lead.CustomerProfileId);
            ViewBag.SalesTeamId = new SelectList(db.SalesTeams, "Id", "Name", lead.SalesTeamId);
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", lead.EventId);
            ViewBag.ApplicationId = new SelectList(db.Applications, "Id", "Name", lead.ApplicationId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", lead.UserId);
            ViewBag.AdvertisementId = new SelectList(db.Advertisements, "Id", "Name", lead.AdvertisementId);
            return View(lead);
        }

        // GET: Leads/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = await db.Leads.FindAsync(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        // POST: Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Lead lead = await db.Leads.FindAsync(id);
            db.Leads.Remove(lead);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
