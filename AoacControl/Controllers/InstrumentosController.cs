using AoacControl.Models;
using AoacControl.Models.Enums;
using AoacControl.Models.ViewModels;
using AoacControl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System.Data;
using System.Diagnostics;

namespace AoacControl.Controllers
{
    public class InstrumentosController : Controller
    {
        private readonly InstrumentoService _instrumentoService;
        private readonly AssociadoService _associadoService;

        public InstrumentosController(InstrumentoService instrumentoService, AssociadoService associadoService)
        {
            _instrumentoService = instrumentoService;
            _associadoService = associadoService;
        }

        // GET: Instrumento
        public async Task<IActionResult> Index()
        {
            var list = await _instrumentoService.FindAllAsync();
            return View(list);
        }

        // GET: Instrumento/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Instrumento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Instrumento instrumento)
        {            
            try
            {
                await _instrumentoService.InsertAsync(instrumento);
                return RedirectToAction(nameof(Index));
            } catch (DbUpdateException ex)
            {
                return RedirectToAction(nameof(Error), new { message = "Número do patrimonio deve ser único - " + ex.Message });
            }
            
        }

        // GET: Instrumento/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrumento = await _instrumentoService.FindByIdAsync(id.Value);

            if (instrumento == null)
            {
                return NotFound();
            }

            return View(instrumento);
        }

        // GET: Instrumento/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var instrumento = await _instrumentoService.FindByIdAsync(id.Value);
            if (instrumento == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }
            //List<Associado> associado = await _associadoService.FindAllAsync();
            InstrumentoFormViewModel viewModel = new InstrumentoFormViewModel { Instrumento = instrumento /*, Associados = associado */};
            return View(viewModel);
        }

        // POST: Instrumento/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Instrumento instrumento)
        {
            if (ModelState.IsValid)
            {
                //var associado = await _associadoService.FindAllAsync();
                var viewModel = new InstrumentoFormViewModel { Instrumento = instrumento /*, Associados = associado*/};
                return View(viewModel);
            }

            if (id != instrumento.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            try
            {
                await _instrumentoService.UpdateAsync(instrumento);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }

        }

        // GET: Instrumento/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var instrumento = await _instrumentoService.FindByIdAsync(id.Value);
            if (instrumento == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }

            return View(instrumento);
        }

        // POST: Paroquias/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _instrumentoService.RemoveAsync(id);
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
    } //class
}
