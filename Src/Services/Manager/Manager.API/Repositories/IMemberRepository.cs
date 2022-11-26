using Manager.API.Entities;

namespace Manager.API.Repositories
{
    public interface IMemberRepository
    {
        public Task<IEnumerable<Member>> GetMembers();
        Task AddMember(Member member);
        Task<bool> UpdateMember(Member projectMember);
        Task<Member> GetMemberById(string id);
    }
}
