using CM.Community_Back_end.Models;
using CmCommunityBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace CM.Community_Back_end.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _context;

        public GroupService(ApplicationDbContext context) {
            _context = context;
        }

        private int getIndexById(Group updatedGroup) {
            int index = 0;
            foreach (Group group in _context.Groups) {
                if (group.groupID == updatedGroup.groupID) {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public async Task<Group> getGroupById(int Id) {
            return await _context.Groups.FindAsync(Id);
        }
        
        public async Task<Group> addGroup(Group newGroup)
        {
            await _context.Groups.AddAsync(newGroup);
            await _context.SaveChangesAsync();

            return newGroup;
        }

        public Task<Group> updateGroup(Group updatedGroup) {
            throw new NotImplementedException();
        }

        public String deleteGroup(Group deletedGroup) {
            //throw new NotImplementedException();
            var testing = _context;
            var itemToRemove = _context.Groups.SingleOrDefault(x => x.groupID == deletedGroup.groupID);

            var returntext = "No group with this ID";

            if (itemToRemove != null)
            {
                _context.Groups.Remove(itemToRemove);
                _context.SaveChanges();
                returntext = "Group with this id has been deleted";
            }
            return returntext;
        }

        public async Task<List<Group>> GetAllGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        //public async Task<Group> updateGroup(Group updatedGroup)
        //{
        //    int index = getIndexById(updatedGroup);
        //    _context.Groups[index] = updatedGroup;
        //    return updatedGroup;
        //}

        //public async Task<Group> deleteGroup(Group deletedGroup)
        //{
        //    int index = getIndexById(deletedGroup);
        //    _context.Groups.RemoveAt(index);
        //    return deletedGroup;
        //}

        //joining group
        public async Task<UserGroup> joinGroup(UserGroup newUserInGroup)
        {
            await _context.UserGroups.AddAsync(newUserInGroup);
            await _context.SaveChangesAsync();

            return newUserInGroup;
        }

        public async Task<List<Group>> getGroupByUserID(int currentUserID)
        {
            var testing = _context;
            var groups = testing.Groups.FromSql($"Select G.groupID, G.Groupname From Groups G INNER JOIN UserGroups UG ON G.groupID = UG.GroupID WHERE UserId = {currentUserID}").ToList<Group>();
            return groups;
        }

        public async Task<List<Group>> getUnjoinedGroupsByUserID(/*int currentUserID*/)
        {
            var testing = _context;
            var createView = testing.Groups.FromSql($"SELECT G.groupName, G.groupID FROM Groups G WHERE G.groupID IN (SELECT G.groupID FROM UserGroups UG WHERE UG.groupID = G.groupID HAVING COUNT(UG.userID) <= 1);").ToList<Group>;
            //var dropView = testing.Groups.FromSql($" DROP VIEW IF EXISTS notjoinedgroups;");
            //var groups = createView.Groups.FromSql($"SELECT * FROM notjoinedgroups WHERE groupID != ANY(SELECT groupID FROM UserGroups WHERE userID = {currentUserID});").ToList<Group>();
            return createView;
        }
    }
}
