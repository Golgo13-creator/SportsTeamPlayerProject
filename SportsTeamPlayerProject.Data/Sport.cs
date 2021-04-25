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
        public string SportName { get; set; }
        [Required]
        public int SportId { get; set; }
        public virtual ICollection<PlayerAssignment> PlayerAssignments { get; set; } = new List<PlayerAssignment>();
        public virtual ICollection<TeamAssignment> TeamAssignments { get; set; } = new List<TeamAssignment>();
    }
}
