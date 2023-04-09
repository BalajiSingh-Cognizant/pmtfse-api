using Project.API.Dtos;

namespace Project.API.Repositories
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<Entities.Project>> GetProjects();
        Task AddProject(Entities.Project project);
        //Task<bool> UpdateProject(Entities.Project projectMember);
        Task<Entities.Project> GetProjectById(string id);
    }
}
