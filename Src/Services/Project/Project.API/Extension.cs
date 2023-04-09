using Project.API.Dtos;

namespace Project.API
{
    public static class Extension
    {
        public static ProjectDto ToDto(this Entities.Project project)
        {
            return new ProjectDto
            {
                 Id = project.Id,
                 Name = project.Name
            };
        }
    }
}
