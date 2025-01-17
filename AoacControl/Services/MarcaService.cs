using AoacControl.Data;
using AoacControl.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AoacControl.Services
{
    public class MarcaService
    {
        private readonly AppDbContext _context;

        public MarcaService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Marca> Marcas => _context.Marcas;

        // Find all
        public async Task<List<Marca>> FindAllAsync()
        {
            return await _context.Marcas.ToListAsync();
        }

        // Insert Async
        public async Task InsertAsync(Marca obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        // Find By Id
        public async Task<Marca> FindByIdAsync(int id)
        {
            return await _context.Marcas.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        // Remove
        public async Task RemoveAsync(int Id)
        {
            var marca = _context.Marcas.Find(Id);
             _context.Remove(marca);
            await _context.SaveChangesAsync();
        }

        // Update
        public async Task UpdateAsync(Marca marca)
        {
            bool hasAny = await _context.Marcas.AnyAsync(obj => obj.Id == marca.Id);
            if (!hasAny)
            {
                throw new Exception($"Id da Marca não encontrada: ");
            }

            try
            {
                _context.Update(marca);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbUpdateConcurrencyException(ex.Message);
            }
        }
    }
}
