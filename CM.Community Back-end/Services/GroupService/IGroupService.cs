using CM.Community_Back_end.Models;

namespace CM.Community_Back_end.Services.GroupService
{
    public interface IGroupService
    {
        Task<List<Group>> GetAllGroups();
        Task<Group> getGroupById(int Id);
        Task<Group> addGroup(Group newGroup);
        Task<Group> updateGroup(Group updatedGroup);
        Task<Group> deleteGroup(Group deletedGroup);
        Task<UserGroup> joinGroup(UserGroup newUserInGroup);
        Task<List<Group>> getGroupByUserID(int currentUserID);
    }
}
