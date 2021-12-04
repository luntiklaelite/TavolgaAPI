using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TavolgaAPI.Models.Entityes.Users
{
    [Table("Contestants")]
    public class Contestant : BaseUser
    {
        public virtual List<ContestantScore> ContestantScores { get; set; } = new List<ContestantScore>();
        public override string Role => "Contestant";
    }
}
