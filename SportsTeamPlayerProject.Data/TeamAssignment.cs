using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamPlayerProject.Data
{
    public class TeamAssignment
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Sport))]
        public string SportName { get; set; }
        public virtual Sport Sport { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Team))]
        public string TeamName { get; set; }
        public virtual Team Team { get; set; }
    }
}
