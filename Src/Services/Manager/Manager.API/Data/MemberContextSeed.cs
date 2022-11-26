using Manager.API.Entities;
using MongoDB.Driver;

namespace Manager.API.Data
{
    public class MemberContextSeed
    {
        public static void SeedData(IMongoCollection<Member> memberCollection)
        {
            bool memberExists = memberCollection.Find(m => true).Any();
            if (!memberExists)
            {
                memberCollection.InsertManyAsync(GetPreconfiguredMembers());
            }
        }

        private static IEnumerable<Member> GetPreconfiguredMembers()
        {
            return new List<Member>()
            {
                new Member
                {                    
                    MemberId = "595959",
                    Name = "Swaroop Singh",
                    Experience = 11,
                    Skills = new List<string>
                    { 
                      "Electrical Engineer",
                      "Communications Engineer",
                      "Awesome Programming Skills",
                      "Leader"
                    },
                    AdditionalInfo = "Currently working at Qualcomm",
                    ProjectStartDate = DateTime.Parse("2011-10-08 06:55:36.955", System.Globalization.CultureInfo.InvariantCulture),
                    ProjectEndDate = DateTime.Parse("2042-10-08 06:55:36.955", System.Globalization.CultureInfo.InvariantCulture),
                    AllocationPercentage = 50
                },
                new Member
                {
                    MemberId = "399584",
                    Name = "Balaji Singh",
                    Experience = 9,
                    Skills = new List<string>
                    {
                      "Communications Engineer",
                      "FSE"
                    },
                    AdditionalInfo = "Currently working at Cognizant",
                    ProjectStartDate = DateTime.Parse("2011-10-08 06:55:36.955", System.Globalization.CultureInfo.InvariantCulture),
                    ProjectEndDate = DateTime.Parse("2049-10-08 06:55:36.955", System.Globalization.CultureInfo.InvariantCulture),
                    AllocationPercentage = 30
                }
            };
        }
    }
}
