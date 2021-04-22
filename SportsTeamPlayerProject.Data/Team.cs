using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamPlayerProject.Data
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }
        [ForeignKey(nameof(Sport))]
        public string Sport { get; set; }
        public virtual Sports Sports { get; set; }
        [ForeignKey(nameof(Player))]
        public string Player { get; set; }
        public virtual Players Players { get; set; }
    }
}
