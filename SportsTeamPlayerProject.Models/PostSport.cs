using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamPlayerProject.Models
{
    public class PostSport
    {
        [Required]
        public string SportName { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public string PlayerName { get; set; }
    }
}
