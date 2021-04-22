using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamPlayerProject.Models
{
    public class PlayerDetails
    {
        public int PlayerNumber { get; set; }

        public string PlayerName { get; set; }

        //[ForeignKey(nameof(Team))]
        public string TeamName { get; set; }
        //[ForeignKey(nameof(Sport))]
        public string SportName { get; set; }
    }
}
