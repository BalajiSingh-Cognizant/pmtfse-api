using MongoDB.Driver;
using Project.API.Entities;

namespace Project.API.Data
{
    public interface IProjectContext
    {
        public IMongoCollection<Entities.Project> Projects { get; }
    }
}
