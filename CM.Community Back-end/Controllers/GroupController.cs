using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Community_Back_end.Models;
using CM.Community_Back_end.Services.GroupService;
using CM.Community_Back_end.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace CM.Community_Back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        public async Task<ActionResult<Group>> addGroup(Group newGroup)
        {
            return CreatedAtAction(nameof(addGroup), await _groupService.addGroup(newGroup));
        }

        [HttpDelete]
        public async Task<ActionResult<List<Group>>> deleteGroup(int groupID)
        {
            return Ok(await _groupService.deleteGroup(groupID));
        }
        
        [HttpPost]
        [Route("join")]
        public async Task<ActionResult<UserGroup>> joinGroup(UserGroup newUserInGroup)
        {
            return CreatedAtAction(nameof(joinGroup), await _groupService.joinGroup(newUserInGroup));
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Group>>> getAllGroups()
        {
            return Ok(await _groupService.GetAllGroups());
        }

        [HttpGet]
        public async Task<ActionResult<List<Group>>> getGroupByUserID(int currentUserID)
        {
            return Ok(await _groupService.getGroupByUserID(currentUserID));
        }

        [HttpGet]
        [Route("GetUnjoined")]
        public async Task<ActionResult<List<Group>>> getUnjoinedGroupsByUserID(/*int currentUserID*/)
        {
            return Ok(await _groupService.getUnjoinedGroupsByUserID(/*currentUserID*/));
        }

    }
}
