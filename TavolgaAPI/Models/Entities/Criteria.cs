using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TavolgaAPI.Models.Entityes
{
    [Table("Criterias")]
    public class Criteria
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        [JsonIgnore,Required]
        public virtual Nomination Nomination { get; set; }
        [Required]
        public int MinScore { get; set; }
        [Required]
        public int MaxScore { get; set; }
        public virtual List<ContestantScore> ContestantScores { get; set; } = new List<ContestantScore>();
        public virtual List<FinalScore> FinalScores { get; set; } = new List<FinalScore>();
    }
}
