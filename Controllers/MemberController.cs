using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LIBRARY_SYSTEM.Models;

namespace LIBRARY_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _MemberService;
        private readonly ILogger<MembersController> _logger;

        public MembersController(IMemberService MemberService, ILogger<MembersController> logger)
        {
            _MemberService = MemberService;
            _logger = logger;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            try
            {
                _logger.LogInformation("Fetching all Members.");
                var Members = await _MemberService.GetAllMembersAsync();
                if (Members == null || !Members.Any())
                {
                    _logger.LogWarning("No Members found.");
                    return NotFound("No Members found.");
                }
                return Ok(Members);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching Members.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching Member with ID {id}");
                var Member = await _MemberService.GetMemberByIdAsync(id);

                if (Member == null)
                {
                    _logger.LogWarning($"Member with ID {id} not found.");
                    return NotFound($"Member with ID {id} not found.");
                }

                return Ok(Member);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the Member.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // PUT: api/Members/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member Member)
        {
            try
            {
                if (id != Member.MemberId)
                {
                    _logger.LogWarning("Member ID mismatch.");
                    return BadRequest("Member ID mismatch.");
                }

                await _MemberService.UpdateMemberAsync(id, Member);
                _logger.LogInformation($"Member with ID {id} updated.");
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _MemberService.GetMemberByIdAsync(id) == null)
                {
                    _logger.LogWarning($"Member with ID {id} not found for update.");
                    return NotFound($"Member with ID {id} not found.");
                }
                else
                {
                    _logger.LogError("Error updating Member.");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the Member.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // POST: api/Members
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member Member)
        {
            try
            {
                if (Member == null)
                {
                    _logger.LogWarning("Received empty Member object.");
                    return BadRequest("Member data cannot be null.");
                }

                await _MemberService.AddMemberAsync(Member);
                _logger.LogInformation($"Member with ID {Member.MemberId} created.");
                return CreatedAtAction("GetMember", new { id = Member.MemberId }, Member);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Member.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            try
            {
                var Member = await _MemberService.GetMemberByIdAsync(id);
                if (Member == null)
                {
                    _logger.LogWarning($"Member with ID {id} not found.");
                    return NotFound($"Member with ID {id} not found.");
                }

                await _MemberService.DeleteMemberAsync(id);
                _logger.LogInformation($"Member with ID {id} deleted.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the Member.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
