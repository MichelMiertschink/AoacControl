using AoacControl.Data;
using AoacControl.Models;
using Microsoft.EntityFrameworkCore;

namespace AoacControl.Services
{
    public class ComunidadeService
    {
        private readonly AppDbContext _context;

        public ComunidadeService(AppDbContext context)
        {
            _context = context;
        }

        // Find all
        public async Task<List<Comunidade>> FindAllAsync()
        {
            return await _context.Comunidades.Include(obj => obj.Paroquia).ToListAsync();
        }

        // Insert Async
        public async Task InsertAsync(Comunidade obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        // Find By Id
        public async Task<Comunidade> FindByIdAsync(int id)
        {
            return await _context.Comunidades.Include(obj => obj.Paroquia).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        // Remove
        public async Task RemoveAsync(int Id)
        {
            var comunidade = _context.Comunidades.Find(Id);
            _context.Remove(comunidade);
            await _context.SaveChangesAsync();
        }

        // Update
        public async Task UpdateAsync(Comunidade objUpdate)
        {
            bool hasAny = await _context.Comunidades.AnyAsync(obj => obj.Id == objUpdate.Id);
            if (!hasAny)
            {
                throw new Exception("Id da Comunidade não encontrada");
            }

            try
            {
                _context.Update(objUpdate);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbUpdateConcurrencyException(ex.Message);
            }
        }
    }
}
