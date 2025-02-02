﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TavolgaAPI.Models.Entityes.Users
{
    [Table("Accessors")]
    public class Accessor: ValuatorBase
    {
        public virtual List<ContestantScore> contestantScores { get; set; }
        public override string Role => "Accessor";
    }
}
