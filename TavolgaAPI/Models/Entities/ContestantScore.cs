﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TavolgaAPI.Models.Entityes.Users;

namespace TavolgaAPI.Models.Entityes
{
    [Table("ContestantScores")]
    public class ContestantScore
    {
        [Key]
        public int CriteriaId { get; set; }
        [Key]
        public int AccessorId { get; set; }
        [Key]
        public int ContestantId { get; set; }
        [ForeignKey("CriteriaId")]
        public virtual Criteria Criteria { get; set; }
        [ForeignKey("ContestantId")]
        public virtual Contestant Contestant { get; set; }
        [ForeignKey("AccessorId")]
        public virtual Accessor Accessor { get; set; }
        [Required]
        public int Score { get; set; }
    }
}
