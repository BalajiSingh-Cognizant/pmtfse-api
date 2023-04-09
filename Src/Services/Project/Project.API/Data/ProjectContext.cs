using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Project.API.Entities;

namespace Project.API.Data
{
    public class ProjectContext : IProjectContext
    {
        public ProjectContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Projects = database.GetCollection<Project.API.Entities.Project>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            ProjectContextSeed.SeedData(Projects);
        }

        public IMongoCollection<Entities.Project> Projects { get; }
    }
}
