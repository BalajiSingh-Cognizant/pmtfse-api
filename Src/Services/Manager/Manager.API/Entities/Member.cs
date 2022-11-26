using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Manager.API.Entities
{
    public class Member
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("MemberId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Member ID cannot be empty")]
        public string MemberId { get; set; } = string.Empty;

        [BsonElement("Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Employee name cannot be empty")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Experience")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Employee experience cannot be empty")]
        public int Experience { get; set; }

        [BsonElement("Skills")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Employee skills cannot be empty")]
        public List<string>? Skills { get; set; }

        [BsonElement("Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Employee Description cannot be empty")]
        public string AdditionalInfo { get; set; } = string.Empty;

        [BsonElement("ProjectStartDate")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Employee Start Date cannot be empty")]
        public DateTime ProjectStartDate { get; set; }

        [BsonElement("ProjectEndDate")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Employee End Date cannot be empty")]
        public DateTime ProjectEndDate { get; set; }

        [BsonElement("AllocationPercentage")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Allocation cannot be empty")]
        public int AllocationPercentage { get; set; }
    }
}
