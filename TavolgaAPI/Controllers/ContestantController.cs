using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TavolgaAPI.Models;
using TavolgaAPI.Models.DTOs;
using TavolgaAPI.Models.Entityes;
using TavolgaAPI.Models.Entityes.Users;
using TavolgaAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace TavolgaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContestantController : ControllerBase
    {
        EfModel DbModel;
        public ContestantController(EfModel model)
        {
            this.DbModel = model;
        }

        /// <summary>
        /// Возвращает участника, наверное только для участника
        /// </summary>
        [Authorize(Roles = "Contestant")]
        [HttpGet("GetContestant")]
        public Contestant GetContestant(int contestantId)
        {
            return DbModel.Contestants.FirstOrDefault(c => c.Id == contestantId);
        }
        
        /// <summary>
        /// Возвращает рейтинг всех участников по номинации 
        /// </summary>
        [Authorize(Roles = "Jury,Accessor")]
        [HttpGet("GetRating")]
        public IActionResult GetRating(int nominationId)
        {
            var nomination = DbModel.Nominations
                .Include(i => i.Criteries)
                    .ThenInclude(i => i.FinalScores)
                .FirstOrDefault(n => n.Id == nominationId);
            if (nomination == null)
                return BadRequest("Такой номинации не существует!");
            return Ok(nomination.Criteries.SelectMany(s => s.FinalScores).Where(s => s.IsAccepted).OrderBy(s => s.Position).Select(s => new FinalScoreDto
            {
                Position = s.Position,
                FinalScore = s.Score,
                Contestant = new ContestantDto
                {
                    Email = s.Contestant.Email,
                    Fio = s.Contestant.FIO,
                    Id = s.Contestant.Id
                }
            }));
        }

        /// <summary>
        /// Ставит оценку участнику
        /// </summary>
        [Authorize(Roles = "Accessor")]
        [HttpPost("AddScore")]
        public IActionResult AddScoreForContenstant([FromBody] AddScoreModel scoreModel)
        {
            //TODO: ОБНОВЛЕНИЕ СРЕДНЕГО БАЛЛА В ТАБЛИЦЕ ФИНАЛЬНЫХ РЕЗУЛЬТАТОВ НАВВЕРНОЕ, ЛИБО ПРОВЕРКА НА ФИНАЛИЗАЦИЮ И ТАМ УЖЕ СЧИТАЕМ СРЕДНЕЕ
            var criteria = DbModel.Criteria.FirstOrDefault(c => c.Id == scoreModel.CriteriaId);
            if (criteria == null)
                return BadRequest("Такого критерия не существует");
            if (criteria.MaxScore < scoreModel.Score || criteria.MinScore > scoreModel.Score)
                return BadRequest($"Значение оценки для данного критерия от {criteria.MinScore} до {criteria.MaxScore}");
            DbModel.ContestantScores.Add(new ContestantScore 
            {
                AccessorId = this.GetCurrentUserId(),
                ContestantId = scoreModel.ContestantId,
                Score = scoreModel.Score,
                CriteriaId = scoreModel.CriteriaId
            });
            DbModel.SaveChanges();
            return Ok();
        }
    }
}
