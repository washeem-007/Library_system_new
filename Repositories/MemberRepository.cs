using LIBRARY_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LIBRARY_SYSTEM.Repositories
{
    public class MemberRepository
    {
        private readonly LibraryContext _context;

        public MemberRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetAllAsync() => await _context.Members.ToListAsync();

        public async Task<Member> GetByIdAsync(int id) => await _context.Members.FindAsync(id);

        public async Task AddAsync(Member Member)
        {
            _context.Members.Add(Member);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Member Member)
        {
            _context.Entry(Member).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Member = await _context.Members.FindAsync(id);
            if (Member != null)
            {
                _context.Members.Remove(Member);
                await _context.SaveChangesAsync();
            }
        }
    }
}
