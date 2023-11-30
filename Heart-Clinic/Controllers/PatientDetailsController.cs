using Heart_Clinic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Heart_Clinic.Controllers
{
    [Authorize]
    public class PatientDetailsController : Controller
    {
        private readonly ClinicContext _context;

        public PatientDetailsController(ClinicContext context)
        {
            _context = context;
        }

        // GET: PatientDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientsTable.ToListAsync());
        }

        // GET: PatientDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetails = await _context.PatientsTable
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patientDetails == null)
            {
                return NotFound();
            }

            return View(patientDetails);
        }

        // GET: PatientDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientDetails/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,FirstName,LastName,Sex,Age,BirthDate,PatientPhone,PatEmail")] PatientDetails patientDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientDetails);
        }

        // GET: PatientDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetails = await _context.PatientsTable.FindAsync(id);
            if (patientDetails == null)
            {
                return NotFound();
            }
            return View(patientDetails);
        }

        // POST: PatientDetails/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientId,FirstName,LastName,Sex,Age,BirthDate,PatientPhone,PatEmail")] PatientDetails patientDetails)
        {
            if (id != patientDetails.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientDetailsExists(patientDetails.PatientId))
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
            return View(patientDetails);
        }

        // GET: PatientDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetails = await _context.PatientsTable
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patientDetails == null)
            {
                return NotFound();
            }

            return View(patientDetails);
        }

        // POST: PatientDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientDetails = await _context.PatientsTable.FindAsync(id);
            _context.PatientsTable.Remove(patientDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientDetailsExists(int id)
        {
            return _context.PatientsTable.Any(e => e.PatientId == id);
        }
    }
}
