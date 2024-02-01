using FluentValidation;
using System;
using TeamPickerUi.Models;
using TeamPickerUi.Pages;

namespace TeamPickerUi.Logic
{
    public class TeamStorage : ITeamStorage
    {
        public List<TeamModel> Teams { get; set; } = new List<TeamModel>();
        public List<MemberModel> Members { get; set; } = new List<MemberModel>();

        public event Action StorageUpdated;

        public void RandomizeTeams()
        {
            foreach (var team in Teams) { team.Members.Clear(); }

            List<MemberModel> membersToAsign = Members.ToList();

            for (int i = 0; i < Members.Count; i++) 
            {
                int teamIndex = i % Teams.Count;
                MemberModel member = membersToAsign[Random.Shared.Next(0,membersToAsign.Count)];
                AddTeamMember(Teams[teamIndex], member);
                membersToAsign.Remove(member);
            }
            StorageUpdated?.Invoke();
        }
        
        public void AddMember(MemberModel member)
        {
            Members.Add(member);            
            StorageUpdated?.Invoke();
        }

        public void RemoveMember(MemberModel member)
        {
            Members.Remove(member);
            StorageUpdated?.Invoke();
        }

        public void AddTeamMember(TeamModel team, MemberModel member)
        {
            team.Members.Add(member);
            StorageUpdated?.Invoke();
        }

        public void RemoveTeamMember(TeamModel team, MemberModel member)
        {
            team.Members.Remove(member);
            StorageUpdated?.Invoke();
        }

        public void AddTeam(TeamModel team)
        {
            Teams.Add(team);
            StorageUpdated?.Invoke();
        }
         public void RemoveTeam(TeamModel team)
        {
            Teams.Remove(team);
            StorageUpdated?.Invoke();
        }
    }
}
