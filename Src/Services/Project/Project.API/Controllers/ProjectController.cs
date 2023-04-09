using Microsoft.AspNetCore.Mvc;
using Project.API.Dtos;
using Project.API.Repositories;
using System.Net;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet(Name = "list")]
        public async Task<IActionResult> GetProjects()
        {
            try
            {
                var projects = (await _projectRepository.GetProjects())
                    .Select(member => member.ToDto());
                return Ok(projects);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{ProjectId}", Name = "GetProject")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProjectDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProjectDto>> GetProjectById(string projectId)
        {

            var project = await _projectRepository.GetProjectById(projectId);
            if (project == null)
            {
                return NotFound();
            }
            return project.ToDto();

        }

        [HttpPost]
        [Route("AddProject")]
        public async Task<ActionResult<ProjectDto>> AddMember([FromBody] Entities.Project project)
        {
            try
            {
                if (project == null)
                    return BadRequest();

                await _projectRepository.AddProject(project);

                return CreatedAtRoute("GetMember", new { id = project.Id }, project);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new project" + ex.Message);
            }
        }

    }
}
