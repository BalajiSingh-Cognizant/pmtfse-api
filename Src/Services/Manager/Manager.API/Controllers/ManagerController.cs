using Manager.API.Dtos;
using Manager.API.Entities;
using Manager.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Manager.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public ManagerController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet(Name = "list")]
        public async Task<IActionResult> GetMembers()
        {
            try
            {
                var projectMembers = (await _memberRepository.GetMembers())
                    .Select(member => member.ToDto());
                return Ok(projectMembers);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{memberId}", Name = "GetMember")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(MemberDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MemberDto>> GetMemberById(string memberId)
        {

            var member = await _memberRepository.GetMemberById(memberId);
            if(member == null)
            {
                return NotFound();
            }
            return member.ToDto();

        }

        [HttpPost]
        [Route("AddMember")]
        public async Task<ActionResult<Member>> AddMember([FromBody] Member member)
        {
            try
            {
                if (member == null)
                    return BadRequest();

                await _memberRepository.AddMember(member);

                return CreatedAtRoute("GetMember", new { id = member.Id }, member);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new team member" + ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Member), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> updatemember([FromBody] Member member)
        {
            return Ok(await _memberRepository.UpdateMember(member));
        }
    }
}
