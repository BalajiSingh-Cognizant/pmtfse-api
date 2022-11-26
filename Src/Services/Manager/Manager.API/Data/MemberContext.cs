using Manager.API.Entities;
using MongoDB.Driver;

namespace Manager.API.Data
{
    public class MemberContext : IMemberContext
    {
        public MemberContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Members = database.GetCollection<Member>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            MemberContextSeed.SeedData(Members);
        }
        public IMongoCollection<Member> Members { get; }
    }
}
