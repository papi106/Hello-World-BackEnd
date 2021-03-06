using HelloWorldWeb.Data;
using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext context;

        public DbTeamService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int AddTeamMember(TeamMember member)
        {
            context.Add(member);
            context.SaveChanges();
            return member.Id;
        }

        public void DeleteTeamMember(int id)
        {
            TeamMember teamMember = context.TeamMembers.Find(id);
            context.TeamMembers.Remove(teamMember);
            context.SaveChanges();
        }

        public void EditTeamMember(int id, string name)
        {
            TeamMember teamMember = context.TeamMembers.Find(id);

            teamMember.Name = name;
            context.Update(teamMember);
            context.SaveChanges();
        }

        public TeamInfo GetTeamInfo()
        {
            TeamInfo teamInfo = new();
            teamInfo.Name = "Patrick";
            teamInfo.TeamMembers = context.TeamMembers.ToList();

            return teamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
