using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavolgaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominationController : ControllerBase
    {
        /// <summary>
        /// Возвращает доступные для жюри/ассессора номинации
        /// </summary>
        [HttpGet("GetAvailableNominations")]
        public void GetAvailableNominations()
        {

        }

        /// <summary>
        /// Изменить номинацию
        /// </summary>
        [HttpPut]
        public void ChangeNomination()
        {

        }
    }
}
