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

        public void Add(string name)
        {
            throw new NotImplementedException();
        }

        public void Add(TeamMember teamMember)
        {
            throw new NotImplementedException();
        }

        public int AddTeamMember(string name)
        {
            TeamMember teamMember = new() { Name = name };
            this.context.Add(teamMember);
            this.context.SaveChangesAsync();

            return teamMember.Id;
        }

        public void DeleteTeamMember(int id)
        {
            var teamMember = context.TeamMembers.Find(id);
            context.TeamMembers.Remove(teamMember);
            context.SaveChangesAsync();
        }

        public void EditTeamMember(int id, string name)
        {
            throw new NotImplementedException();
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
