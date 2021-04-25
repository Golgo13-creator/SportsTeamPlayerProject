using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamPlayerProject.Data
{
    public class PlayerAssignment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Player))]
        public string PlayerName { get; set; }
        public virtual Player Player { get; set; }
        [ForeignKey(nameof(Sport))]
        public string SportName { get; set; }
        public virtual Sport Sport { get; set; }
    }
}
