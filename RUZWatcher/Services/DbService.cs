using Microsoft.EntityFrameworkCore;
using RUZWatcher.Data;
using RUZWatcher.Models;

namespace RUZWatcher.Services
{
    /// <summary>
    /// Služba pre CRUD operácie s účtovnými jednotkami a závierkami.
    /// </summary>
    public class DbService
    {
        private readonly ApplicationDbContext _context;

        public DbService(ApplicationDbContext context)
        {
            _context = context;
        }


        // CRUD pre účtovné jednotky

        public async Task<List<UctovnaJednotka>> GetAllJednotkyAsync()
        {
            return await _context.UctovneJednotky
                .Include(u => u.UctovneZavierky)
                .OrderBy(u => u.NazovSubjektu)
                .ToListAsync();
        }

        public async Task<UctovnaJednotka?> GetJednotkaByIdAsync(long id)
        {
            return await _context.UctovneJednotky
                .Include(u => u.UctovneZavierky)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddJednotkaAsync(UctovnaJednotka jednotka)
        {
            var najdenaJednotka = await _context.UctovneJednotky.FindAsync(jednotka.Id);
            if (najdenaJednotka == null)
            {
                _context.UctovneJednotky.Add(jednotka);
                await _context.SaveChangesAsync();
            }
            else
            {
                await UpdateJednotkaAsync(jednotka);
            }
        }

        public async Task UpdateJednotkaAsync(UctovnaJednotka jednotka)
        {
            var existing = await _context.UctovneJednotky.FindAsync(jednotka.Id);
            if (existing == null)
                return;

            _context.Entry(existing).CurrentValues.SetValues(jednotka);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJednotkaAsync(long id)
        {
            var jednotka = await _context.UctovneJednotky.FindAsync(id);
            if (jednotka != null)
            {
                _context.UctovneJednotky.Remove(jednotka);
                await _context.SaveChangesAsync();
            }
        }
    }
}