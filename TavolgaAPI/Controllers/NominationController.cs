using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TavolgaAPI.Extensions;
using TavolgaAPI.Models;
using TavolgaAPI.Models.DTOs;
using TavolgaAPI.Models.Entityes;

namespace TavolgaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominationController : ControllerBase
    {
        EfModel DbModel;
        public NominationController(EfModel model)
        {
            this.DbModel = model;
        }
        /// <summary>
        /// Добавить номинацию
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddNomination(int eventId, Nomination nomination)
        {
            nomination.Event = DbModel.Events.FirstOrDefault(e => e.Id == eventId);
            if (nomination.Event == null)
                return BadRequest("Такого мероприятия не существует!");
            DbModel.Nominations.Add(nomination);
            return Ok(nomination);
        }

        /// <summary>
        /// Удаляет номинацию
        /// </summary>
        /// <param name="nominationId"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult DeleteNomination(int nominationId)
        {
            try
            {
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        ///// <summary>
        ///// Изменить номинацию
        ///// </summary>
        //[Authorize(Roles = "Admin")]
        //[HttpPut]
        //public void ChangeNomination()
        //{

        //}
        [Authorize(Roles = "Jury,Accessor")]
        [HttpPut("ChangeAvailableNominations")]
        public IActionResult ChangeAvailableNominations([FromBody] EventNominationId event_nomination)
        {
            int userId = this.GetCurrentUserId();
            var valuator = DbModel.ValuatorBases
                .Include(i => i.Nominations)
                    .ThenInclude(i => i.Event)
                .FirstOrDefault(v => v.Id == userId);
            if (!valuator.Events.Any(e => e.Id == event_nomination.EventId))
                return BadRequest("Вы не можете редактировать свои номинации!");
            if (event_nomination.IsDeleteAction)
                valuator.Nominations.RemoveAll(n => n.Id == event_nomination.NominationId);
            else
                valuator.Nominations.Add(DbModel.Nominations.FirstOrDefault(n => n.Id == event_nomination.NominationId));
            return Ok();
        }

        /// <summary>
        /// Возвращает доступные для жюри/ассессора номинации
        /// </summary>
        [Authorize(Roles = "Jury,Accessor")]
        [HttpGet("GetAvailableNominations")]
        public IEnumerable<Nomination> GetAvailableNominations()
        {
            int userId = this.GetCurrentUserId();
            return DbModel.ValuatorBases
                .Include(i => i.Nominations)
                    .ThenInclude(i => i.Criteries)
                        .ThenInclude(i => i.ContestantScores)
                            .ThenInclude(i => i.Contestant)
                .Include(i => i.Nominations)
                    .ThenInclude(i => i.Criteries)
                        .ThenInclude(i => i.FinalScores)
                .FirstOrDefault(v => v.Id == userId).Nominations;
        }
    }
}
