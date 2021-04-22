using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamPlayerProject.Data
{
    public class Sport
    {
        [Key]
        public int SportId { get; set; }
        [Required]
        public string SportName { get; set; }
        [ForeignKey(nameof(Team))]
        public string TeamName { get; set; }
        public virtual Team Team { get; set; }
        [ForeignKey(nameof(Player))]
        public string PlayerName { get; set; }
        public virtual Player Player { get; set; }
    }
}
