using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavolgaAPI.Models.DTOs
{
    public class FinalScoreDto
    {
        public ContestantDto Contestant { get; set; }
        public int FinalScore { get; set; }
        public int Position { get; set; }
    }
}
