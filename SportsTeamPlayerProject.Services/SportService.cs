using SportsTeamPlayerProject.Data;
using SportsTeamPlayerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamPlayerProject.Services
{
    public class SportService
    {
        private readonly Guid _userId;
        public SportService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSport(PostSport model)
        {
            var entity =
                new Sport()
                {
                    SportName = model.SportName
                    //SportId = model.SportId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sports.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateSport(PutSport model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sports
                        .Single(e => e.SportId == model.SportId);
                entity.SportName = model.SportName;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSport(int sportId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sports
                        .Single(e => e.SportId == sportId);
                ctx.Sports.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SportListItem> GetSport()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sports
                        .Select(
                            e =>
                                new SportListItem
                                {
                                    SportId = e.SportId,
                                    SportName = e.SportName
                                }

                        );
                return query.ToArray();
            }
        }
    }
}
