using AoacControl.Data;
using AoacControl.Models;
using Microsoft.EntityFrameworkCore;

namespace AoacControl.Services
{
    public class ParoquiaService
    {
        private readonly AppDbContext _context;

        public ParoquiaService(AppDbContext context)
        {
            _context = context;
        }

        // Find all
        public async Task<List<Paroquia>> FindAllAsync()
        {
            return await _context.Paroquias.Include(obj => obj.UniaoParoquial).ToListAsync();
        }

        // Insert Async
        public async Task InsertAsync(Paroquia obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        // Find By Id
        public async Task<Paroquia> FindByIdAsync(int id)
        {
            return await _context.Paroquias.Include(obj => obj.UniaoParoquial).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        // Remove
        public async Task RemoveAsync(int Id)
        {
            var paroquia = _context.Paroquias.Find(Id);
            _context.Remove(paroquia);
            await _context.SaveChangesAsync();
        }

        // Update
        public async Task UpdateAsync(Paroquia objUpdate)
        {
            bool hasAny = await _context.Paroquias.AnyAsync(obj => obj.Id == objUpdate.Id);
            if (!hasAny)
            {
                throw new Exception("Id da Paroquia não encontrada");
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
