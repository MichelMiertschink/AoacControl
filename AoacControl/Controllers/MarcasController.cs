using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AoacControl.Models;
using AoacControl.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AoacControl.Models.ViewModels;
using System.Diagnostics;


namespace AoacControl.Controllers
{
    public class MarcasController : Controller
    {
        private readonly MarcaService _marcaService;

        public MarcasController(MarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        // GET: Marcas
        public async Task<IActionResult> Index()
        {
            var list = await _marcaService.FindAllAsync();
            return View(list);
        }

        // GET: Marcas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marcas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Marca marca)
        {
            if (ModelState.IsValid)
            {
                await _marcaService.InsertAsync(marca);
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // GET: Marcas/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _marcaService.FindByIdAsync(id.Value);

            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // GET: Marcas/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _marcaService.FindByIdAsync(id.Value);
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        // POST: Marcas/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Marca marca)
        {
            if (id != marca.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            if (ModelState.IsValid)
            {
                await _marcaService.UpdateAsync(marca);
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // GET: Marcas/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var marca = await _marcaService.FindByIdAsync(id.Value);
            if (marca == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }

            return View(marca);
        }

        // POST: Marcas/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _marcaService.RemoveAsync(id);
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
