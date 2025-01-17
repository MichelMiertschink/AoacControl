using AoacControl.Data;
using AoacControl.Models;
using Microsoft.EntityFrameworkCore;

namespace AoacControl.Services
{
    public class UniaoParoquialService
    {
        private readonly AppDbContext _context;

        public UniaoParoquialService(AppDbContext context)
        {
            _context = context;
        }

        // Find all
        public async Task<List<UniaoParoquial>> FindAllAsync()
        {
            return await _context.UnioesParoquiais.ToListAsync();
        }

        // Insert Async
        public async Task InsertAsync(UniaoParoquial obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        // Find By Id
        public async Task<UniaoParoquial> FindByIdAsync(int id)
        {
            return await _context.UnioesParoquiais.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        // Remove
        public async Task RemoveAsync(int Id)
        {
            var ups = _context.UnioesParoquiais.Find(Id);
            _context.Remove(ups);
            await _context.SaveChangesAsync();
        }

        // Update
        public async Task UpdateAsync(UniaoParoquial objUpdate)
        {
            bool hasAny = await _context.UnioesParoquiais.AnyAsync(obj => obj.Id == objUpdate.Id);
            if (!hasAny)
            {
                throw new Exception("Id da Uniao Paroquial não encontrada");
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
