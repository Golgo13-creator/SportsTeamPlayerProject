using SportsTeamPlayerProject.Data;
using SportsTeamPlayerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamPlayerProject.Services
{
    public class PlayerService
    {
        private readonly Guid _userId;

        public PlayerService(Guid userId)
        {
            _userId = userId;
        }


        public bool PostPlayer(PlayerCreate model)
        {
            var entity = new Player
            {
                //OwnerId = _userId,
                PlayerId = model.PlayerId,
                PlayerName = model.PlayerName,
                TeamName = model.TeamName,
                SportName = model.SportName
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(entity);
                return ctx.SaveChanges() > 0;
            }

        }
        public IEnumerable<PlayerListItem> GetPlayers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                    .Players
                    .Select(p => new PlayerListItem
                    {
                        PlayerId = p.PlayerId,
                        PlayerName = p.PlayerName
                    });

                return query.ToList();
            }
        }

        public PlayerDetails GetPlayerByTeam(string teamName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var player =
                    ctx
                    .Players//PlayerAssignment table
                    .SingleOrDefault(p => p.TeamName == teamName);

                if (player is null)
                {
                    return null;
                }

                return new PlayerDetails
                {
                    PlayerId = player.PlayerId,
                    PlayerName = player.PlayerName,
                    TeamName = player.TeamName,
                    SportName = player.SportName
                };
            }
        }

        public PlayerDetails GetPlayerBySport(string sportName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var player =
                    ctx
                    .Players
                    .SingleOrDefault(p => p.SportName == sportName);

                if (player is null)
                {
                    return null;
                }

                return new PlayerDetails
                {
                    PlayerId = player.PlayerId,
                    PlayerName = player.PlayerName,
                    SportName = player.SportName,
                    TeamName = player.TeamName
                };
            }
        }

        public bool PutPlayers(PlayerEdit newPlayerData)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldPlayerData =
                    ctx
                    .Players
                    .SingleOrDefault(p => p.PlayerId == newPlayerData.PlayerId);

                oldPlayerData.PlayerId = newPlayerData.PlayerId;
                oldPlayerData.PlayerName = newPlayerData.PlayerName;
                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeletePlayers(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var playerToDelete =
                    ctx
                    .Players
                    .SingleOrDefault(p => p.PlayerId == playerId);

                if (playerToDelete != null)
                {
                    ctx.Players.Remove(playerToDelete);

                    return ctx.SaveChanges() > 0;
                }

                return false;
            }
        }

    }
}
