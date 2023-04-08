using Manager.API.Dtos;
using Manager.API.Entities;

namespace Manager.API
{
    public static class Extensions
    {
        public static MemberDto ToDto(this Member member)
        {
            return new MemberDto
            {
                MemberId = member.MemberId,
                AdditionalInfo = member.AdditionalInfo,
                AllocationPercentage = member.AllocationPercentage,
                Experience = member.Experience,
                Name = member.Name,
                ProjectEndDate = member.ProjectEndDate,
                ProjectStartDate = member.ProjectStartDate,
                Skills = member.Skills

            };
        }
    }
}
