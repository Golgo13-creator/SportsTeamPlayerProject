using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamPlayerProject.Models
{
    public class PlayerDetails
    {
        public int PlayerNumber { get; set; }

        public string PlayerName { get; set; }

        [ForeignKey(nameof(Team))]

        [ForeignKey(nameof(Sport))]
    }
}
