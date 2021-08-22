using System;
using System.Diagnostics;

namespace CSharpFeatures
{
    [DebuggerDisplay("{Name}[{Id}]")]
    public class TeamMember
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, Birthday = {BirthDate}";
        }

    }
}