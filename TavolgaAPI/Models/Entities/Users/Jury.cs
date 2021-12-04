using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TavolgaAPI.Models.Entityes.Users
{
    [Table("Jurys")]
    public class Jury : ValuatorBase
    {
        public virtual List<FinalScore> FinalScores { get; set; } = new List<FinalScore>();
        public override string Role => "Jury";
    }
}
