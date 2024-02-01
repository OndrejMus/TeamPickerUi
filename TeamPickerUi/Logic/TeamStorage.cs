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

        public int RatingPerWin = 100;
        public int RatingPerLoss = 100;

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

        public void SetTeamToCloseRating()
        {
            foreach (var team in Teams) { team.Members.Clear(); }

            // add members
            List<MemberModel> tempMembers = Members.ToList();

            while (tempMembers.Count > 0)
            {
                MemberModel topRatingMember = tempMembers.MaxBy(x => x.Rating);

                TeamModel lowestScoreTeam = Teams.MinBy(x => x.GetTeamRating());

                AddTeamMember(lowestScoreTeam, topRatingMember);
                tempMembers.Remove(topRatingMember);
            }

            StorageUpdated?.Invoke();
        }

        public void SetWiningTeam(TeamModel winningTeam)
        {
            winningTeam.WinCount += 1;
            foreach (var member in winningTeam.Members)
            {
                member.Rating += RatingPerWin;
                member.WinCount += 1;
            }

            foreach (var team in Teams)
            {
                if (team != winningTeam)
                {
                    team.LossCount += 1;
                    foreach (var member in team.Members)
                    {
                        member.Rating -= RatingPerLoss;
                        member.LossCount += 1;
                    }
                }
            }

            StorageUpdated?.Invoke();
        }

            public void AddMember(MemberModel member)
        {
            Members.Add(member);            
            StorageUpdated?.Invoke();
        }

        public void DeleteMember(MemberModel member)
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
         public void DeleteTeam(TeamModel team)
        {
            Teams.Remove(team);
            StorageUpdated?.Invoke();
        }
    }
}
