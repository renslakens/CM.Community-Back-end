using CM.Community_Back_end.Models;

namespace CM.Community_Back_end.Services.GroupService
{
    public interface IGroupService
    {
        Task<List<Group>> GetAllGroups();
        Task<Group> getGroupById(int Id);
        Task<List<Group>> addGroup(Group newGroup);
        Task<List<Group>> updateGroup(Group updatedGroup);
        Task<List<Group>> deleteGroup(Group deletedGroup);
        Task<List<UserGroup>> joinGroup(Group newUserInGroup);
    }
}
