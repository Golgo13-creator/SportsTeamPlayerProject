using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamPlayerProject.Models
{
    public class TeamDetail
    {
        public int TeamId { get; set; }
        [Required]
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }
        [Required]
        [Display(Name = "Sport")]
        public string Sport { get; set; }
        [Required]
        [Display(Name = "Player")]
        public string Player { get; set; }
    }
}
