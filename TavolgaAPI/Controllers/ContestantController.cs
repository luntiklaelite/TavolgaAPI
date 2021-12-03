using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavolgaAPI.Controllers
{
    //TODO: ДОБАВИТЬ В КАЖДЫЙ КОНТРОЛЛЕР МЕТОДЫ [CRU] ДЛЯ АДМИНИСТРАТОРА
    //ДОБАВИТЬ ЕЩЁ МЕТОДЫ В КАКОЙ-ТО КОНТРОЛЛЕР
    //Может осуществлять финализацию результатов работы асессоров
    //Может проголосовать за участника в спорном моменте;

    [Route("api/[controller]")]
    [ApiController]
    public class ContestantController : ControllerBase
    {
        /// <summary>
        /// Возвращает участника, наверное только для участника
        /// </summary>
        [HttpGet("GetContestant")]
        public void GetContestant()
        {

        }

        /// <summary>
        /// Возвращает участников по номинации
        /// </summary>
        [HttpGet("GetContestantsByNomination")]
        public void GetContestantsByNomination()
        {

        }
        /// <summary>
        /// Возвращает рейтинг всех участников
        /// </summary>
        [HttpGet("GetRating")]
        public void GetRating()
        {

        }

        /// <summary>
        /// Ставит оценку участнику
        /// </summary>
        [HttpPut("AddScore")]
        public void AddScoreForContenstant()
        {

        }
    }
}
