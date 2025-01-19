using AoacControl.Models.ViewModels;
using AoacControl.Models;
using AoacControl.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AoacControl.Controllers
{
    public class ComunidadesController : Controller
    {
        private readonly ComunidadeService _comunidadeService;
        private readonly ParoquiaService _paroquiaService;

        public ComunidadesController(ComunidadeService comunidadeService, ParoquiaService paroquiaService)
        {
            _comunidadeService = comunidadeService;
            _paroquiaService = paroquiaService;
        }

        // GET: Comunidades
        public async Task<IActionResult> Index()
        {
            var list = await _comunidadeService.FindAllAsync();
            return View(list);
        }

        // GET: Comunidades/Create
        public async Task<IActionResult> Create()
        {
            var paroquia = await _paroquiaService.FindAllAsync();
            var viewModel = new ComunidadeFormViewModel { Paroquias = paroquia };
            return View(viewModel);
        }

        // POST: Comunidades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Comunidade comunidade)
        {
            if (ModelState.IsValid)
            {
                var paroquia = await _paroquiaService.FindAllAsync();
                var viewModel = new ComunidadeFormViewModel { Paroquias = paroquia};
                return View(viewModel);

            }
            await _comunidadeService.InsertAsync(comunidade);
            return RedirectToAction(nameof(Index));
        }

        // GET: Comunidades/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var comunidade = await _comunidadeService.FindByIdAsync(id.Value);

            if (comunidade == null)
            {
                return NotFound();
            }

            return View(comunidade);
        }

        // GET: Comunidades/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var comunidade = await _comunidadeService.FindByIdAsync(id.Value);
            if (comunidade == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }
            List<Paroquia> paroquia = await _paroquiaService.FindAllAsync();
            ComunidadeFormViewModel viewModel = new ComunidadeFormViewModel { Comunidade = comunidade, Paroquias = paroquia};
            return View(viewModel);
        }

        // POST: Comunidades/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Comunidade comunidade)
        {
            if (ModelState.IsValid)
            {
                var paroquia = await _paroquiaService.FindAllAsync();
                var viewModel = new ComunidadeFormViewModel { Comunidade = comunidade, Paroquias = paroquia };
                return View(viewModel);
            }

            if (id != comunidade.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            try
            {
                await _comunidadeService.UpdateAsync(comunidade);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }

        }

        // GET: Comunidades/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var comunidade = await _comunidadeService.FindByIdAsync(id.Value);
            if (comunidade == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }

            return View(comunidade);
        }

        // POST: Paroquias/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _comunidadeService.RemoveAsync(id);
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
