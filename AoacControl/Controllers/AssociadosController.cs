using AoacControl.Models;
using AoacControl.Models.ViewModels;
using AoacControl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AoacControl.Controllers
{
    public class AssociadosController : Controller
    {
        private readonly AssociadoService _associadoService;
        private readonly ComunidadeService _comunidadeService;
        private readonly InstrumentoService _instrumentoService;

        public AssociadosController(AssociadoService associadoService, ComunidadeService comunidadeService, InstrumentoService instrumentoService)
        {
            _associadoService = associadoService;
            _comunidadeService = comunidadeService;
            _instrumentoService = instrumentoService;
        }

        // GET: Associados
        public async Task<IActionResult> Index()
        {
            var list = await _associadoService.FindAllAsync();
            return View(list);
        }

        // GET: Associados/Create
        public async Task<IActionResult> Create()
        {
            var comunidade = await _comunidadeService.FindAllAsync();
            var instrumento = await _instrumentoService.FindAllAsync();
            var viewModel = new AssociadoFormViewModel { Comunidades = comunidade, Instrumentos = instrumento };
            return View(viewModel);
        }

        // POST:  Associados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Associado associado)
        {
            if (ModelState.IsValid)
            {
                var comunidade = await _comunidadeService.FindAllAsync();
                var instrumento = await _instrumentoService.FindAllAsync();
                var viewModel = new AssociadoFormViewModel { Comunidades = comunidade, Instrumentos = instrumento };
                return View(viewModel);
            }
            await _associadoService.InsertAsync(associado);
            return RedirectToAction(nameof(Index));
        }

        // GET: Associados/Details
        public async Task<IActionResult> Details (int? id)
        {
            if (id != null) 
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var associado = await _associadoService.FindByIdAsync(id.Value);

            if (associado == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }
            
            return View(associado);
        }

        // GET: Associados/Edit
        public async Task<IActionResult> Edit (int? id)
        {
            if (id != null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var associado = await _associadoService.FindByIdAsync(id.Value);

            if (associado == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }
            List<Comunidade> comunidade = await _comunidadeService.FindAllAsync();
            List<Instrumento> instrumento = await _instrumentoService.FindAllAsync();
            AssociadoFormViewModel viewModel = new AssociadoFormViewModel { Associado = associado, Comunidades = comunidade, Instrumentos = instrumento };
            return View(viewModel);
        }

        // POST: Associados/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, Associado associado)
        {
            if (ModelState.IsValid)
            {
                var comunidade = await _comunidadeService.FindAllAsync();
                var instrumento = await _instrumentoService.FindAllAsync();
                var viewModel = new AssociadoFormViewModel { Comunidades = comunidade, Instrumentos = instrumento };
                return View(viewModel); 
            }

            if (id != associado.Id) 
            { 
                return RedirectToAction(nameof(Error), new {message = "Id não fornecido"});
            }

            try
            {
                await _associadoService.UpdateAsync(associado);
                return RedirectToAction(nameof(Index));
            } 
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        // GET: Associado/Delete
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var associado = await _associadoService.FindByIdAsync(id.Value);
            if (associado == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(associado);
        }

        // POST: Associado/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _associadoService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction($"Não é possível excluir: {ex.Message}");
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
