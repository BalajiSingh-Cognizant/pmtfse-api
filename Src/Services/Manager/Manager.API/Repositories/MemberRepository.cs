using Manager.API.Data;
using Manager.API.Entities;
using MongoDB.Driver;

namespace Manager.API.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IMemberContext _context;
        public MemberRepository(IMemberContext context)
        {
            _context = context;
        }

        public async Task AddMember(Member member)
        {
            await _context.Members.InsertOneAsync(member);
        }

        public async Task<Member> GetMemberById(string id)
        {
            var member = (Member)await _context
                                    .Members
                                    .Find(m => m.MemberId == id)
                                    .FirstOrDefaultAsync();

            return member;
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            return await _context
                            .Members
                            .Find(m => true)
                            .ToListAsync();
        }

        public async Task<bool> UpdateMember(Member member)
        {
            var updatedResult = await _context
                                        .Members
                                        .ReplaceOneAsync(filter: g => g.MemberId == member.MemberId, replacement: member);

            return updatedResult.IsAcknowledged
                    && updatedResult.ModifiedCount > 0;
        }
    }
}
