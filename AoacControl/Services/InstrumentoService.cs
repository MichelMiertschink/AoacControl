using AoacControl.Data;
using AoacControl.Models;
using Microsoft.EntityFrameworkCore;

namespace AoacControl.Services
{
    public class InstrumentoService
    {
        private readonly AppDbContext _context;

        public InstrumentoService(AppDbContext context)
        {
            _context = context;
        }

        // Find all
        public async Task<List<Instrumento>> FindAllAsync()
        {
            return await _context.Instrumentos.Include(obj => obj.Marca).ToListAsync();
        }

        // Insert Async
        public async Task InsertAsync(Instrumento obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        // Find By Id
        public async Task<Instrumento> FindByIdAsync(int id)
        {
            return await _context.Instrumentos.Include(obj => obj.Marca).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        // Remove
        public async Task RemoveAsync(int Id)
        {
            var instrumento = _context.Instrumentos.Find(Id);
            _context.Remove(instrumento);
            await _context.SaveChangesAsync();
        }

        // Update
        public async Task UpdateAsync(Instrumento objUpdate)
        {
            bool hasAny = await _context.Instrumentos.AnyAsync(obj => obj.Id == objUpdate.Id);
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
