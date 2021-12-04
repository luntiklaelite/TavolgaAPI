using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavolgaAPI.Models.DTOs
{
    public class AddScoreModel
    {
        public int CriteriaId { get; set; }
        public int ContestantId { get; set; }
        public int Score { get; set; }
    }
}
