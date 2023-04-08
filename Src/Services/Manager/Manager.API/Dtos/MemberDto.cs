using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Manager.API.Dtos
{
    public class MemberDto
    {
        public string MemberId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int Experience { get; set; }

        public List<string>? Skills { get; set; }

        public string AdditionalInfo { get; set; } = string.Empty;

        public DateTime ProjectStartDate { get; set; }

        public DateTime ProjectEndDate { get; set; }

        public int AllocationPercentage { get; set; }
    }
}
