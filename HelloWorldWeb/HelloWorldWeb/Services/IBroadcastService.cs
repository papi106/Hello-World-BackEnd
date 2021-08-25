namespace HelloWorldWebApp.Services
{
    public interface IBroadcastService
    {
        void NewTeamMemberAdded(string name, int id);
        void DeleteTeamMember(int id);
        void EditTeamMember(string name, int id);
    }
}