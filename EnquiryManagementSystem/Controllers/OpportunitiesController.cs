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
    public class OpportunitiesController : Controller
    {
        private EnquiryModelContainer db = new EnquiryModelContainer();

        // GET: Opportunities
        public async Task<ActionResult> Index()
        {
            var opportunities = db.Opportunities.Include(o => o.EnquiryRisk).Include(o => o.EnquiryStage).Include(o => o.EnquiryStatu).Include(o => o.Priority);
            return View(await opportunities.ToListAsync());
        }

        // GET: Opportunities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opportunity opportunity = await db.Opportunities.FindAsync(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            return View(opportunity);
        }

        // GET: Opportunities/Create
        public ActionResult Create()
        {
            ViewBag.EnquiryRiskId = new SelectList(db.EnquiryRisks, "Id", "Name");
            ViewBag.EnquiryStageId = new SelectList(db.EnquiryStages, "Id", "Name");
            ViewBag.EnquiryStatuId = new SelectList(db.EnquiryStatus, "Id", "Name");
            ViewBag.PriorityId = new SelectList(db.Priorities, "Id", "Name");
            return View();
        }

        // POST: Opportunities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Potentials,Probability,ExpectedClosedDate,RemainderDate,Owner,CreatedOn,ModifiedOn,CreatedBy,ModifiedBy,IsMarkComplete,IsCRMUpdated,IsFlag,EnquiryStageId,PriorityId,EnquiryStatuId,EnquiryRiskId")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                db.Opportunities.Add(opportunity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EnquiryRiskId = new SelectList(db.EnquiryRisks, "Id", "Name", opportunity.EnquiryRiskId);
            ViewBag.EnquiryStageId = new SelectList(db.EnquiryStages, "Id", "Name", opportunity.EnquiryStageId);
            ViewBag.EnquiryStatuId = new SelectList(db.EnquiryStatus, "Id", "Name", opportunity.EnquiryStatuId);
            ViewBag.PriorityId = new SelectList(db.Priorities, "Id", "Name", opportunity.PriorityId);
            return View(opportunity);
        }

        // GET: Opportunities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opportunity opportunity = await db.Opportunities.FindAsync(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnquiryRiskId = new SelectList(db.EnquiryRisks, "Id", "Name", opportunity.EnquiryRiskId);
            ViewBag.EnquiryStageId = new SelectList(db.EnquiryStages, "Id", "Name", opportunity.EnquiryStageId);
            ViewBag.EnquiryStatuId = new SelectList(db.EnquiryStatus, "Id", "Name", opportunity.EnquiryStatuId);
            ViewBag.PriorityId = new SelectList(db.Priorities, "Id", "Name", opportunity.PriorityId);
            return View(opportunity);
        }

        // POST: Opportunities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Potentials,Probability,ExpectedClosedDate,RemainderDate,Owner,CreatedOn,ModifiedOn,CreatedBy,ModifiedBy,IsMarkComplete,IsCRMUpdated,IsFlag,EnquiryStageId,PriorityId,EnquiryStatuId,EnquiryRiskId")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opportunity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EnquiryRiskId = new SelectList(db.EnquiryRisks, "Id", "Name", opportunity.EnquiryRiskId);
            ViewBag.EnquiryStageId = new SelectList(db.EnquiryStages, "Id", "Name", opportunity.EnquiryStageId);
            ViewBag.EnquiryStatuId = new SelectList(db.EnquiryStatus, "Id", "Name", opportunity.EnquiryStatuId);
            ViewBag.PriorityId = new SelectList(db.Priorities, "Id", "Name", opportunity.PriorityId);
            return View(opportunity);
        }

        // GET: Opportunities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opportunity opportunity = await db.Opportunities.FindAsync(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            return View(opportunity);
        }

        // POST: Opportunities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Opportunity opportunity = await db.Opportunities.FindAsync(id);
            db.Opportunities.Remove(opportunity);
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
