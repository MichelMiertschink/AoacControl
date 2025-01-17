using AoacControl.Data;
using AoacControl.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AoacControl.Services
{
    public class AssociadoService
    {
        private readonly AppDbContext _context;

        public AssociadoService(AppDbContext context)
        {
            _context = context;
        }

        // Find All
        public async Task<List<Associado>> FindAllAsync()
        {
            return await _context.Associados.Include(obj => obj.Comunidade).ToListAsync();
        }

        // Insert Async
        public async Task InsertAsync(Associado obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        // Find By Id
        public async Task<Associado> FindByIdAsync(int id)
        {
            return await _context.Associados.Include(obj => obj.Comunidade).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        // Remove
        public async Task RemoveAsync(int id)
        {
            var associado = _context.Associados.Find(id);
            _context.Remove(associado);
            await _context.SaveChangesAsync();
        }

        // Update
        public async Task UpdateAsync(Associado associado)
        {
            bool hasAny = await _context.Associados.AnyAsync(obj => obj.Id == associado.Id);
            if (!hasAny)
            {
                throw new Exception("Id do Associado não encontrada");
            }

            try
            {
                _context.Update(associado);
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException ex)
            {
                throw new DBConcurrencyException(ex.Message);
            }
        }
    }
}
