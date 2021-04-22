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
        public string Team { get; set; }
        public virtual Teams Teams { get; set; }
        [ForeignKey(nameof(Player))]
        public string Player { get; set; }
        public virtual Players Players { get; set; }
    }
}
