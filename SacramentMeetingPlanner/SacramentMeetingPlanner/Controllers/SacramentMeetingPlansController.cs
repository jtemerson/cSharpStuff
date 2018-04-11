using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class SacramentMeetingPlansController : Controller
    {
        private readonly MeetingContext _context;

        public SacramentMeetingPlansController(MeetingContext context)
        {
            _context = context;
        }

        // GET: SacramentMeetingPlans
        public async Task<IActionResult> Index(string sortOrder, string searchString)

        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var sacramentPlan = from s in _context.sacramentMeetingPlans
                                select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sacramentPlan = sacramentPlan.Where(s => s.Topic.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "Date":
                    sacramentPlan = sacramentPlan.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    sacramentPlan = sacramentPlan.OrderByDescending(s => s.Date);
                    break;
                default:
                    sacramentPlan = sacramentPlan.OrderBy(s => s.SacramentMeetingPlanID);
                    break;
            }
            return View(await sacramentPlan.AsNoTracking().ToListAsync());
        }

        // GET: SacramentMeetingPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacramentMeetingPlan = await _context.sacramentMeetingPlans
                .SingleOrDefaultAsync(m => m.SacramentMeetingPlanID == id);
            if (sacramentMeetingPlan == null)
            {
                return NotFound();
            }

            return View(sacramentMeetingPlan);
        }

        // GET: SacramentMeetingPlans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SacramentMeetingPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SacramentMeetingPlanID,Date,OpeningPrayer,ClosingPrayer,OpeningHymn,SacramentHymn,ClosingHymn,Talk1,Talk2,Talk3,Topic,LeaderName,Presiding,Announcements")] SacramentMeetingPlan sacramentMeetingPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sacramentMeetingPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sacramentMeetingPlan);
        }

        // GET: SacramentMeetingPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacramentMeetingPlan = await _context.sacramentMeetingPlans.SingleOrDefaultAsync(m => m.SacramentMeetingPlanID == id);
            if (sacramentMeetingPlan == null)
            {
                return NotFound();
            }
            return View(sacramentMeetingPlan);
        }

        // POST: SacramentMeetingPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SacramentMeetingPlanID,Date,OpeningPrayer,ClosingPrayer,OpeningHymn,SacramentHymn,ClosingHymn,Talk1,Talk2,Talk3,Topic,LeaderName,Presiding,Announcements")] SacramentMeetingPlan sacramentMeetingPlan)
        {
            if (id != sacramentMeetingPlan.SacramentMeetingPlanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sacramentMeetingPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SacramentMeetingPlanExists(sacramentMeetingPlan.SacramentMeetingPlanID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sacramentMeetingPlan);
        }

        // GET: SacramentMeetingPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacramentMeetingPlan = await _context.sacramentMeetingPlans
                .SingleOrDefaultAsync(m => m.SacramentMeetingPlanID == id);
            if (sacramentMeetingPlan == null)
            {
                return NotFound();
            }

            return View(sacramentMeetingPlan);
        }

        // POST: SacramentMeetingPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sacramentMeetingPlan = await _context.sacramentMeetingPlans.SingleOrDefaultAsync(m => m.SacramentMeetingPlanID == id);
            _context.sacramentMeetingPlans.Remove(sacramentMeetingPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SacramentMeetingPlanExists(int id)
        {
            return _context.sacramentMeetingPlans.Any(e => e.SacramentMeetingPlanID == id);
        }
    }
}