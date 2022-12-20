using CM.Community_Back_end.Models;
using CmCommunityBackend.Data;

namespace CM.Community_Back_end.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _context;

        private static List<Group> groups = new List<Group>{
            new Group{groupName = "Backend"},
            new Group{groupName = "Frontend"}
        };

        private static List<UserGroup> usersInGroup = new List<UserGroup>
        {
            new UserGroup{userID = 1, groupID = 1}
        };

        private int getIndexById(Group group)
        {
            return groups.FindIndex((g) => g.groupID == group.groupID);
        }
        public async Task<List<Group>> addGroup(Group newGroup)
        {
            groups.Add(newGroup);
            return groups;
        }

        public async Task<List<Group>> GetAllGroups()
        {
            return groups;
        }

        public async Task<Group> getGroupById(int Id)
        {
            return groups.FirstOrDefault(c => c.groupID == Id);
        }

        public async Task<List<Group>> updateGroup(Group updatedGroup)
        {
            int index = getIndexById(updatedGroup);
            groups[index] = updatedGroup;
            return groups;
        }
        public async Task<List<Group>> deleteGroup(Group deletedGroup)
        {
            int index = getIndexById(deletedGroup);
            groups.RemoveAt(index);
            return groups;
        }

        //joining group
        public async Task<List<UserGroup>> joinGroup(UserGroup newUserInGroup)
        {
            usersInGroup.Add(newUserInGroup);
            return usersInGroup;
        }
    }
}
