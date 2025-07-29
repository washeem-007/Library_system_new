using LIBRARY_SYSTEM.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
public class MemberService : IMemberService
{
    private readonly LibraryContext _context;
    public MemberService(LibraryContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Member>> GetAllMembersAsync()
    {
        return await _context.Members.ToListAsync();
    }
    public async Task<Member> GetMemberByIdAsync(int id)
    {
        return await _context.Members.FindAsync(id);
    }
    public async Task AddMemberAsync(Member Member)
    {
        _context.Members.Add(Member);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateMemberAsync(int id, Member Member)
    {
        _context.Entry(Member).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    public async Task DeleteMemberAsync(int id)
    {
        var Member = await _context.Members.FindAsync(id);
        if (Member != null)
        {
            _context.Members.Remove(Member);
            await _context.SaveChangesAsync();
        }
    }
}