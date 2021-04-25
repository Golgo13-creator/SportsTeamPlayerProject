using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamPlayerProject.Data
{
    public class Player
    {
        [Key]
        public string PlayerName { get; set; }
        [Required]
        public int PlayerId { get; set; }

        [ForeignKey(nameof(Team))]
        public string TeamName { get; set; }
        public virtual Team Team { get; set; }
        [ForeignKey(nameof(Sport))]
        public string SportName { get; set; }
        public virtual Sport Sport { get; set; }
        public virtual ICollection<PlayerAssignment> PlayerAssignments { get; set; } = new List<PlayerAssignment>();
    }
}
