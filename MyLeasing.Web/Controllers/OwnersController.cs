using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Helpers;
using MyLeasing.Web.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyLeasing.Web.Controllers
{
    public class OwnersController : Controller
    {
        private readonly IOwnersRepository _ownersRepository;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public OwnersController(
            IOwnersRepository ownersRepository,
            IUserHelper userHelper,
            IImageHelper imageHelper,
            IConverterHelper converterHelper)
        {
            _ownersRepository = ownersRepository;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
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
        public async Task<IActionResult> Create([Bind("Id,Document,FirstName,LastName,FixedPhone,CellPhone,Address")] OwnerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {


                    path = await _imageHelper.UploadImageAsync(model.ImageFile, "owners"); 
                }

                var owners = _converterHelper.ToOwners(model, path, true);

                //TODO: Modificar para o user que estiver logado
                owners.User = await _userHelper.GetUserByEmailAsync("joao.vieitas2@gmail.com");
                await _ownersRepository.CreateAsync(owners);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
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

            var model = _converterHelper.ToOwnerViewModel(owners);
            return View(model);
        }



        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OwnerViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var path = model.ImageUrl;

                    if (model.ImageFile != null && model.ImageFile.Length > 0)
                    {


                        path = await _imageHelper.UploadImageAsync(model.ImageFile, "owners");
                    }


                    var owners = _converterHelper.ToOwners(model, path, false);

                    //TODO: Modificar para o user que tiver logado
                    owners.User = await _userHelper.GetUserByEmailAsync("joao.vieitas2@gmail.com");
                    await _ownersRepository.UpdateAsync(owners);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _ownersRepository.ExistAsync(model.Id))
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
            return View(model);
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
