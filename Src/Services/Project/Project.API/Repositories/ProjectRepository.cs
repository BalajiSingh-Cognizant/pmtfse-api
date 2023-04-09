using MongoDB.Driver;
using Project.API.Data;
using Project.API.Dtos;

namespace Project.API.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IProjectContext _context;
        public ProjectRepository(IProjectContext projectContext)
        {
            _context = projectContext;
        }
        public async Task AddProject(Entities.Project project)
        {
            await _context.Projects.InsertOneAsync(project);
        }

        public async Task<Entities.Project> GetProjectById(string id)
        {
            return (Entities.Project)await _context
                                    .Projects
                                    .Find(p => p.Id.ToString() == id)
                                    .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.Project>> GetProjects()
        {
            return await _context
                            .Projects
                            .Find(p => true)
                            .ToListAsync();
        }

        //public Task<bool> UpdateProject(Entities.Project projectMember)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
