﻿using System;
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
        public string TeamName { get; set; }
        [Required]
        public int TeamId { get; set; }
        [ForeignKey(nameof(Sport))]
        public string SportName { get; set; }
        public virtual Sport Sport { get; set; }
        public virtual ICollection<TeamAssignment> TeamAssignments { get; set; } = new List<TeamAssignment>(); 
    }
}
