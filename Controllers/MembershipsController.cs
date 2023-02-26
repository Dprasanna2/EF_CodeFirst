using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CODEFIRST.Models;

namespace CODEFIRST.Controllers
{
    public class MembershipsController : Controller
    {
        private readonly DatabaseContext _context;

        public MembershipsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Memberships
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.MembershipsRecord.Include(m => m.MembershipCategory).Include(m => m.PersonDetail);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Memberships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MembershipsRecord == null)
            {
                return NotFound();
            }

            var membership = await _context.MembershipsRecord
                .Include(m => m.MembershipCategory)
                .Include(m => m.PersonDetail)
                .FirstOrDefaultAsync(m => m.Membership_Id == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // GET: Memberships/Create
        public IActionResult Create()
        {
            ViewData["Membership_Category_Id"] = new SelectList(_context.MembershipCategories, "Membership_Category_Id", "Membership_Category_Name");
            ViewData["Person_Id"] = new SelectList(_context.PersonDetails, "Person_Id", "EmailId");
            return View();
        }

        // POST: Memberships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Membership_Id,Account_Balance,Person_Id,Membership_Category_Id")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Membership_Category_Id"] = new SelectList(_context.MembershipCategories, "Membership_Category_Id", "Membership_Category_Name", membership.Membership_Category_Id);
            ViewData["Person_Id"] = new SelectList(_context.PersonDetails, "Person_Id", "EmailId", membership.Person_Id);
            return View(membership);
        }

        // GET: Memberships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MembershipsRecord == null)
            {
                return NotFound();
            }

            var membership = await _context.MembershipsRecord.FindAsync(id);
            if (membership == null)
            {
                return NotFound();
            }
            ViewData["Membership_Category_Id"] = new SelectList(_context.MembershipCategories, "Membership_Category_Id", "Membership_Category_Name", membership.Membership_Category_Id);
            ViewData["Person_Id"] = new SelectList(_context.PersonDetails, "Person_Id", "EmailId", membership.Person_Id);
            return View(membership);
        }

        // POST: Memberships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Membership_Id,Account_Balance,Person_Id,Membership_Category_Id")] Membership membership)
        {
            if (id != membership.Membership_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembershipExists(membership.Membership_Id))
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
            ViewData["Membership_Category_Id"] = new SelectList(_context.MembershipCategories, "Membership_Category_Id", "Membership_Category_Name", membership.Membership_Category_Id);
            ViewData["Person_Id"] = new SelectList(_context.PersonDetails, "Person_Id", "EmailId", membership.Person_Id);
            return View(membership);
        }

        // GET: Memberships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MembershipsRecord == null)
            {
                return NotFound();
            }

            var membership = await _context.MembershipsRecord
                .Include(m => m.MembershipCategory)
                .Include(m => m.PersonDetail)
                .FirstOrDefaultAsync(m => m.Membership_Id == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // POST: Memberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MembershipsRecord == null)
            {
                return Problem("Entity set 'DatabaseContext.MembershipsRecord'  is null.");
            }
            var membership = await _context.MembershipsRecord.FindAsync(id);
            if (membership != null)
            {
                _context.MembershipsRecord.Remove(membership);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembershipExists(int id)
        {
            return _context.MembershipsRecord.Any(e => e.Membership_Id == id);
        }
    }
}
