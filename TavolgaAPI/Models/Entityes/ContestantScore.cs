using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TavolgaAPI.Models.Entityes.Users;

namespace TavolgaAPI.Models.Entityes
{
    public class ContestantScore
    {
        [Key]
        public int CriteriaId { get; set; }
        [Key]
        public int AccessorId { get; set; }
        [Key]
        public int ContestantId { get; set; }
        [ForeignKey("CriteriaId")]
        public Criteria Criteria { get; set; }
        [ForeignKey("ContestantId")]
        public Contestant Contestant { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public bool IsAccepted { get; set; } = false;
    }
}
