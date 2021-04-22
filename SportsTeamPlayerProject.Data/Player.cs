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
        public int PlayerNumber { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string PlayerName { get; set; }

        [ForeignKey(nameof(Team))]

        [ForeignKey(nameof(Sport))]


    }
}
