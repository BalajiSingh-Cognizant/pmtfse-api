using MongoDB.Driver;

namespace Project.API.Data
{
    public class ProjectContextSeed
    {
        public static void SeedData(IMongoCollection<Entities.Project> projectsCollection)
        {
            bool projectExists = projectsCollection.Find(p => true).Any();
            if (!projectExists)
            {
                projectsCollection.InsertManyAsync(GetPreconfiguredProjects());
            }
        }
        private static IEnumerable<Entities.Project> GetPreconfiguredProjects()
        {
            return new List<Entities.Project>()
            {
                new Entities.Project
                {
                    Name = "Twitter API"
                },
                new Entities.Project
                {
                    Name = "FSE B3"
                }
            };
        }
    }
}
