using LIBRARY_SYSTEM.Models;
public interface IMemberService
{
Task<IEnumerable<Member>> GetAllMembersAsync();
Task<Member> GetMemberByIdAsync(int id);
Task AddMemberAsync(Member Member);
Task UpdateMemberAsync(int id, Member Member);
Task DeleteMemberAsync(int id);
}