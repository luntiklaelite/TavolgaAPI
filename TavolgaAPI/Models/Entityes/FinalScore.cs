using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TavolgaAPI.Models.Entityes.Users;

namespace TavolgaAPI.Models.Entityes
{
    [Table("FinalScores")]
    public class FinalScore
    {
        [Key]
        public int CriteriaId { get; set; }
        [Key]
        public int ContestantId { get; set; }
        [Required]
        public int Score { get; set; }
        [ForeignKey("ContestantId")]
        public Contestant contestant { get; set; }
        [ForeignKey("CriteriaId")]
        public Criteria Criteria { get; set; }
        [Required]
        public Jury Juri { get; set; }
        [Required]
        public int Position { get; set; }
    }
}
