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
                OwnerId = _userId,
                PlayerNumber = model.PlayerNumber,
                PlayerName = model.PlayerName
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
                    .Where(p => p.OwnerId == _userId)
                    .Select(p => new PlayerListItem
                    {
                        PlayerNumber = p.PlayerNumber,
                        PlayerName = p.PlayerName
                    });

                return query.ToList();
            }
        }

        public PlayerDetails GetPlayerByTeam(string Team)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var player =
                    ctx
                    .Players
                    .SingleOrDefault(p => p.OwnerId == _userId && p.Team == team);

                if (player is null)
                {
                    return null;
                }

                return new PlayerDetails
                {
                    PlayerNumber = player.PlayerNumber,
                    PlayerName = player.PlayerName,
                    Team = player.Team
                };
            }
        }

        public PlayerDetails GetPlayerBySport(string Sport)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var player =
                    ctx
                    .Players
                    .SingleOrDefault(p => p.OwnerId == _userId && p.Sport == sport);

                if (player is null)
                {
                    return null;
                }

                return new PlayerDetails
                {
                    PlayerNumber = player.PlayerNumber,
                    PlayerName = player.PlayerName,
                    Sport = player.Sport
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
                    .SingleOrDefault(p => p.OwnerId == _userId && p.PlayerNumber == newPlayerData.PlayerNumber);

                oldPlayerData.PlayerNumber = newPlayerData.PlayerNumber;
                oldPlayerData.PlayerName = newPlayerData.PlayerName;
                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeletePlayers(int PlayerNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var playerToDelete =
                    ctx
                    .Players
                    .SingleOrDefault(p => p.OwnerId == _userId && p.PlayerNumber == playerNumber);

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
