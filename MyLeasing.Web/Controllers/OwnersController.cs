using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data;
using MyLeasing.Web.Data.Entities;

namespace MyLeasing.Web.Controllers
{
    public class OwnersController : Controller
    {
        private readonly IOwnersRepository _ownersRepository;

        public OwnersController(IOwnersRepository ownersRepository)
        {
            _ownersRepository = ownersRepository;
        }

        // GET: Owners
        public IActionResult Index()
        {
            return View(_ownersRepository.GetAll());
        }

        // GET: Owners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owners = await _ownersRepository.GetByIdAsync(id.Value);
            if (owners == null)
            {
                return NotFound();
            }

            return View(owners);
        }

        // GET: Owners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Document,FirstName,LastName,FixedPhone,CellPhone,Address")] Owners owners)
        {
            if (ModelState.IsValid)
            {
                await _ownersRepository.CreateAsync(owners);
                return RedirectToAction(nameof(Index));
            }
            return View(owners);
        }

        // GET: Owners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owners = await _ownersRepository.GetByIdAsync(id.Value);
            if (owners == null)
            {
                return NotFound();
            }
            return View(owners);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Document,FirstName,LastName,FixedPhone,CellPhone,Address")] Owners owners)
        {
            if (id != owners.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ownersRepository.UpdateAsync(owners);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _ownersRepository.ExistAsync(owners.Id))
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
            return View(owners);
        }

        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owners = await _ownersRepository.GetByIdAsync(id.Value);
            if (owners == null)
            {
                return NotFound();
            }

            return View(owners);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var owners = await _ownersRepository.GetByIdAsync(id);
            await _ownersRepository.DeleteAsync(owners);
            return RedirectToAction(nameof(Index));
        }
    }
}
