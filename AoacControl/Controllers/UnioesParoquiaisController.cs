using AoacControl.Models.ViewModels;
using AoacControl.Models;
using AoacControl.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AoacControl.Controllers
{
    public class UnioesParoquiaisController : Controller
    {
        private readonly UniaoParoquialService _uniaoParoquialService;

        public UnioesParoquiaisController(UniaoParoquialService uniaoParoquialService)
        {
            _uniaoParoquialService = uniaoParoquialService;
        }

        // GET: União Paroquial
        public async Task<IActionResult> Index()
        {
            var list = await _uniaoParoquialService.FindAllAsync();
            return View(list);
        }

        // GET: Paroquias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paroquias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UniaoParoquial uniaoParoquial)
        {
            if (ModelState.IsValid)
            {
                await _uniaoParoquialService.InsertAsync(uniaoParoquial);
                return RedirectToAction(nameof(Index));
            }
            return View(uniaoParoquial);
        }

        // GET: Paroquias/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Paroquia = await _uniaoParoquialService.FindByIdAsync(id.Value);

            if (Paroquia == null)
            {
                return NotFound();
            }

            return View(Paroquia);
        }

        // GET: Paroquias/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Paroquia = await _uniaoParoquialService.FindByIdAsync(id.Value);
            if (Paroquia == null)
            {
                return NotFound();
            }
            return View(Paroquia);
        }

        // POST: Paroquias/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UniaoParoquial UniaoParoquial)
        {
            if (id != UniaoParoquial.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            if (ModelState.IsValid)
            {
                await _uniaoParoquialService.UpdateAsync(UniaoParoquial);
                return RedirectToAction(nameof(Index));
            }
            return View(UniaoParoquial);
        }

        // GET: Paroquias/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var Paroquia = await _uniaoParoquialService.FindByIdAsync(id.Value);
            if (Paroquia == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }

            return View(Paroquia);
        }

        // POST: Paroquias/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _uniaoParoquialService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error), new
                {
                    message = "Não é possível excluir - " + ex.Message
                });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
