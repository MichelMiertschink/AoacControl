using AoacControl.Models.ViewModels;
using AoacControl.Models;
using AoacControl.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AoacControl.Controllers
{
    public class ParoquiasController : Controller
    {
        private readonly ParoquiaService _paroquiaService;
        private readonly UniaoParoquialService _uniaoParoquialService;

        public ParoquiasController(ParoquiaService paroquiaService, UniaoParoquialService uniaoParoquialService)
        {
            _paroquiaService = paroquiaService;
            _uniaoParoquialService = uniaoParoquialService;
        }

        // GET: Paroquias
        public async Task<IActionResult> Index()
        {
            var list = await _paroquiaService.FindAllAsync();
            return View(list);
        }

        // GET: Paroquias/Create
        public async Task<IActionResult> Create()
        {
            var unioesParoquiais = await _uniaoParoquialService.FindAllAsync();
            var viewModel = new ParoquiaFormViewModel { UnioesParoquiais = unioesParoquiais };
            return View(viewModel);
        }

        // POST: Paroquias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paroquia paroquia)
        {
            if (ModelState.IsValid)
            {
                var unioesParoquiais = await _uniaoParoquialService.FindAllAsync();
                var viewModel = new ParoquiaFormViewModel { UnioesParoquiais = unioesParoquiais };
                return View(viewModel);
                
            }
            await _paroquiaService.InsertAsync(paroquia);
            return RedirectToAction(nameof(Index));
        }

        // GET: Paroquias/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Paroquia = await _paroquiaService.FindByIdAsync(id.Value);

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
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var paroquia = await _paroquiaService.FindByIdAsync(id.Value);
            if (paroquia == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }
            List<UniaoParoquial> unioesParoquiais = await _uniaoParoquialService.FindAllAsync();
            ParoquiaFormViewModel viewModel = new ParoquiaFormViewModel { Paroquia = paroquia, UnioesParoquiais = unioesParoquiais };
            return View(viewModel);
        }

        // POST: Paroquias/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Paroquia paroquia)
        {
            if (ModelState.IsValid)
            {
                var unioesParoquiais = await _uniaoParoquialService.FindAllAsync();
                var viemModel = new ParoquiaFormViewModel { Paroquia = paroquia, UnioesParoquiais = unioesParoquiais };
                return View(viemModel);
            }

            if (id != paroquia.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }
                        
            try
            {
                await _paroquiaService.UpdateAsync(paroquia);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex) 
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
            
        }

        // GET: Paroquias/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var paroquia = await _paroquiaService.FindByIdAsync(id.Value);
            if (paroquia == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }

            return View(paroquia);
        }

        // POST: Paroquias/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _paroquiaService.RemoveAsync(id);
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
