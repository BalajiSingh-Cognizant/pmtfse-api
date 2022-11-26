using Manager.API.Entities;
using MongoDB.Driver;

namespace Manager.API.Data
{
    public interface IMemberContext
    {
        IMongoCollection<Member> Members { get; }
    }
}
