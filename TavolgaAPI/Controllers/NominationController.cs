using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TavolgaAPI.Models;
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
        /// 
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

        /// <summary>
        /// Изменить номинацию
        /// </summary>
        [HttpPut]
        public void ChangeNomination()
        {

        }

        /// <summary>
        /// Возвращает доступные для жюри/ассессора номинации
        /// </summary>
        [HttpGet("GetAvailableNominations")]
        public IEnumerable<Nomination> GetAvailableNominations()
        {
            return DbModel.Nominations;
        }

        
    }
}
